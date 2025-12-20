using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDetected : MonoBehaviour
{
    [SerializeField] LayerMask Fall_Objects;
    [SerializeField] LayerMask Objects;
    [SerializeField] LayerMask Wall;
    [SerializeField] LayerMask []layers;

    [SerializeField] GameObject RightHand;
    [SerializeField] Camera MainCamera;

    protected bool IsKey = false;
    bool IsCandle = false;
    [SerializeField] GameObject[] ObjectsSequence;

    [SerializeField] protected GameObject HitBox_Lock; // Added this serialized field to provide the required argument  

  
    [SerializeField] Vector3 Pos_OpenDrawer;
    [SerializeField] int SpeedDrawer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    // Update is called once per frame
    void Update()
    {


        

        RaycastHit hit = new RaycastHit();
        

        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(MainCamera.transform.position, ray.direction * 16, Color.red);

        // Rayo que detecta el layer "Wall" para cambiar el layer del rayo que detecta los objetos interactuables a "Object"
        if (Physics.Raycast(ray, out hit, 16, layers[3]))
        {

            layers[2] = LayerMask.GetMask("Nothing");
        }
        else if (!Physics.Raycast(ray, out hit, 16, layers[3]))
        {
            layers[2] = LayerMask.GetMask("Object");

        }

        // Rayo que detecta el layer "Fall_Object"
        if (Physics.Raycast(ray, out hit, 16, layers[1]))
        {
            // Si se hace click derecho en el objeto, se le añade un Rigidbody para que caiga
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Hit object: " + hit.transform.name);
                hit.transform.AddComponent<Rigidbody>();
            }

        }
        // Rayo que detecta el layer "Object"
        if (Physics.Raycast(ray, out hit, 16, layers[2]) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hit object: " + hit.transform.name);
            // Si se detecta una llave, se desactiva el objeto en la escena, se activa la variable IsKey y se muestra el objeto en la mano del jugador
            if (hit.collider.CompareTag("Key"))
            {
                hit.collider.gameObject.SetActive(false);
                IsKey = true;
                ObjectsSequence[0].SetActive(true);
                ObjectsSequence[0].transform.position = RightHand.transform.position;
                ObjectsSequence[0].transform.SetParent(RightHand.transform, true);
            }


        }
        if (Physics.Raycast(ray, out hit, 16, layers[4]) && IsKey)
        {
            
            Pos_OpenDrawer = new Vector3(Pos_OpenDrawer.x, hit.transform.localPosition.y, Pos_OpenDrawer.z);
            if (Input.GetMouseButton(0) && HitBox_Lock.TryGetComponent<Rigidbody>(out _))
            {
                hit.transform.localPosition = Vector3.MoveTowards(hit.transform.localPosition, Pos_OpenDrawer, SpeedDrawer * Time.deltaTime);
                 Debug.Log("AAAA");
            }

        }

        Locking(HitBox_Lock); // Pass the required argument to the Locking method  
    }


      



    void Locking(GameObject HitBox_Lock)
    {
        if (IsKey)
        {   
            HitBox_Lock.layer = LayerMask.NameToLayer("Fall_Object");

        }
    }


    


}



