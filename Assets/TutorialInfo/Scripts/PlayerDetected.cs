using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDetected : MonoBehaviour
{
    [SerializeField] LayerMask Fall_Objects;
    [SerializeField] LayerMask Objects;
    [SerializeField] LayerMask Wall;
    [SerializeField] LayerMask[] layers;

    [SerializeField] GameObject RightHand;
    [SerializeField] Camera MainCamera;
    bool IsKey = false;
    bool IsCandle = false;
    [SerializeField] GameObject KeyEquipment;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit = new RaycastHit();
        
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        float distance = Vector3.Distance(MainCamera.transform.position, ray.direction);

        Debug.DrawRay(MainCamera.transform.position, ray.direction * 16, Color.red);

        // Rayo que detecta el layer "Wall" para cambiar el layer del rayo que detecta los objetos interactuables a "Nothing"
        if (Physics.Raycast(ray, out hit, 16, layers[3]))
        {

            layers[2] = LayerMask.GetMask("Nothing");

        }
        // Rayo que detecta el layer "Wall" para cambiar el layer del rayo que detecta los objetos interactuables a "Object"
        else if (!Physics.Raycast(ray, out hit, 16, layers[3]))
        {
            layers[2] = LayerMask.GetMask("Object");

        }
        // Rayo que detecta el layer "Fall_Object"
        if (Physics.Raycast(ray, out hit, 16, layers[1]))
        {
            // Si se hace click derecho en el objeto, se le añade un Rigidbody para que caiga
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("Hit object: " + hit.transform.name);
                hit.transform.AddComponent<Rigidbody>();
            }

        }
        // Rayo que detecta el layer "Object"
        if (Physics.Raycast(ray, out hit, 16, layers[2]) && Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Hit object: " + hit.transform.name);
            // Si se detecta una llave, se desactiva el objeto en la escena, se activa la variable IsKey y se muestra el objeto en la mano del jugador
            if (hit.collider.CompareTag("Key"))
            {
                hit.collider.gameObject.SetActive(false);
                IsKey = true;
                KeyEquipment.SetActive(true);
                KeyEquipment.transform.position = RightHand.transform.position;
                KeyEquipment.transform.SetParent(RightHand.transform, true);
            }

            if (hit.collider.CompareTag("Candle"))
            {
                hit.collider.gameObject.SetActive(false);
                IsCandle = true;
                KeyEquipment.SetActive(true);
                KeyEquipment.transform.position = RightHand.transform.position;
                KeyEquipment.transform.SetParent(RightHand.transform, true);
            }
        }

        

    }


}
