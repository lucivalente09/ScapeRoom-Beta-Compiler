using System;
using System.Collections;
using System.Threading.Tasks;
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

    [SerializeField] bool Tools_Active = false;

    [SerializeField] bool IsCandle = false;
    bool IsLighter = false;
    protected bool IsKey = false;
    bool IsHammer = false;
    bool IsPaper = false;
    [SerializeField] GameObject[] Planks;
    [SerializeField] int int_Planks = 4;


    [SerializeField] GameObject[] ObjectsEquipment;

    [SerializeField] protected GameObject HitBox_Lock; // Added this serialized field to provide the required argument  


    [SerializeField] Vector3 Pos_OpenDrawer;
    [SerializeField] int SpeedDrawer;

    [SerializeField] GameObject Exam_Candle;
    [SerializeField] GameObject Fire, IceObject;


    [SerializeField] float Transparency;

    public float Transpayency_Int
    {
        get
        {
            return Transparency;
        }

        set
        {

            Transparency = Mathf.Clamp(value, 0, 1);
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        Transpayency_Int = 1;

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit = new RaycastHit();


        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(MainCamera.transform.position, ray.direction * 16, Color.red);

        Debug.Log("Child count: " + RightHand.transform.childCount);

        if (RightHand.transform.childCount > 0)
        {
            Tools_Active = true;
        }
        else if (RightHand.transform.childCount <= 0)
        {
            Tools_Active = false;
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
        if (Physics.Raycast(ray, out hit, 16, layers[2]))
        {

            Debug.Log("Hit object: " + hit.transform.name);
            // Si se detecta una llave, se desactiva el objeto en la escena, se activa la variable IsKey y se muestra el objeto en la mano del jugador
            if (hit.collider.CompareTag("Key") && Input.GetMouseButtonDown(0))
            {


                if (!Tools_Active)
                {
                    hit.collider.gameObject.SetActive(false);

                    IsKey = true;
                    ObjectsEquipment[0].SetActive(true);
                    ObjectsEquipment[0].transform.position = RightHand.transform.position;
                    ObjectsEquipment[0].transform.SetParent(RightHand.transform, true);


                }

            }

            if (hit.collider.CompareTag("Candle") && Input.GetMouseButtonDown(0))
            {
                if (!Tools_Active)
                {

                    IsCandle = true;
                    hit.collider.transform.position = RightHand.transform.position;

                    hit.collider.transform.SetParent(RightHand.transform, true);

                }


            }

            if (hit.collider.CompareTag("Lighter") && Input.GetMouseButtonDown(0))
            {

                if (!Tools_Active && IsCandle)
                {
                    hit.collider.gameObject.SetActive(false);
                    IsLighter = true;
                    ObjectsEquipment[2].SetActive(true);
                    ObjectsEquipment[2].transform.position = RightHand.transform.position;
                    ObjectsEquipment[2].transform.SetParent(RightHand.transform, true);


                }

            }

            if (hit.collider.CompareTag("Exam_Candle") && IsCandle)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Debug.Log("Exam");

                    if (RightHand.transform.childCount <= 0)
                    {
                        Debug.Log("No hay objeto en la mano");
                    }

                    if (RightHand.transform.childCount >= 1)
                    {
                        GameObject ChildHand = RightHand.gameObject.transform.transform.GetChild(0).gameObject;
                        Debug.Log(RightHand.gameObject.transform.transform.GetChild(0).gameObject);
                        ChildHand.transform.position = Exam_Candle.transform.position;
                        ChildHand.transform.SetParent(Exam_Candle.transform, true);
                        ChildHand.tag = "Untagged";

                    }

                }

                if (Input.GetMouseButtonDown(0) && IsLighter)
                {
                    if (!Tools_Active)
                    {
                        Debug.Log("Exam_Lighter");
                        Fire.SetActive(true);
                        StartCoroutine(TransparencyLoad());
                    }


                }
            }

            if (hit.collider.CompareTag("Hammer") && Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.SetActive(false);
                IsHammer = true;
                ObjectsEquipment[3].SetActive(true);
                ObjectsEquipment[3].transform.position = RightHand.transform.position;
                ObjectsEquipment[3].transform.SetParent(RightHand.transform, true);

                PlanksFall();
            }


            if (hit.collider.CompareTag("Paper") && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Paper_Detected");
                hit.collider.gameObject.SetActive(false);
                IsPaper = true;
                ObjectsEquipment[4].SetActive(true);
                ObjectsEquipment[4].transform.position = RightHand.transform.position;
                ObjectsEquipment[4].transform.SetParent(RightHand.transform, true);

            }

            if (hit.collider.CompareTag("Exam_Paper") && IsPaper)
            {
                if (!Tools_Active)
                {

                }
            }



            Debug.Log(Transparency);
            // Rayo que detecta el layer "Wall" para cambiar el layer del rayo que detecta los objetos interactuables a "Object"
            if (Physics.Raycast(ray, out hit, 16, layers[3]))
            {

                layers[2] = LayerMask.GetMask("Nothing");
            }
            else if (!Physics.Raycast(ray, out hit, 16, layers[3]))
            {
                layers[2] = LayerMask.GetMask("Object");

            }


            if (Physics.Raycast(ray, out hit, 16, layers[4]) && IsKey)
            {

                Pos_OpenDrawer = new Vector3(Pos_OpenDrawer.x, hit.transform.localPosition.y, Pos_OpenDrawer.z);
                if (HitBox_Lock.TryGetComponent<Rigidbody>(out _))
                {

                    Destroy(ObjectsEquipment[0]);

                    if (Input.GetMouseButton(0))
                    {
                        hit.transform.localPosition = Vector3.MoveTowards(hit.transform.localPosition, Pos_OpenDrawer, SpeedDrawer * Time.deltaTime);
                        Debug.Log("AAAA");
                    }
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

        void PlanksFall()
        {
            if (IsHammer && int_Planks > 0)
            {
                foreach (GameObject plank in Planks)
                {
                    plank.layer = LayerMask.NameToLayer("Fall_Object");
                    int_Planks--;
                }

            }
        }



        IEnumerator TransparencyLoad()
        {
            Material Ice = IceObject.GetComponent<Renderer>().material;
            while (Transpayency_Int >= 0)
            {
                Transpayency_Int -= 0.1f;


                Ice.SetFloat("_Transparent", Transpayency_Int);
                yield return new WaitForSeconds(0.1f);
                Ice.SetColor("_Color_Back", Color.black);
                yield return null;
            }

            if (Transpayency_Int == 0)
            {
                Destroy(IceObject);
            }


        }
    }
}