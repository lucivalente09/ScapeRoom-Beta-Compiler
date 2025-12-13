using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    [SerializeField] LayerMask Fall_Objects;

    [SerializeField]Camera MainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out hit, 100, Fall_Objects))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
               
                hit.transform.AddComponent<Rigidbody>();
            }
                
        }



    }
}
