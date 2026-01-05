using UnityEngine;

public class PlayerMovement :MonoBehaviour
{

    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Arrowabove;
    [SerializeField] GameObject Arrowleft;
    [SerializeField] GameObject Arrowright;
    [SerializeField] GameObject Arrowbelow;
    [SerializeField] GameObject[] ListWayPoints;


    [SerializeField] int WayPointsClick = 0;

    GameObject PositionWayPoint;

    Quaternion RotationWayPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arrowleft.SetActive(false);
        Arrowright.SetActive(false);

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (WayPointsClick)
        {

            // Si se vuelve atras o sea click = 0 entonces
            case 0:
                PositionWayPoint = ListWayPoints[0];
                RotationWayPoint = Quaternion.identity;
                Arrowabove.SetActive(true);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);
                Arrowbelow.SetActive(false);
                break;

            // Si se hace click en la flacha de arriba entonces 
            case 1:
                PositionWayPoint = ListWayPoints[1];
                RotationWayPoint = Quaternion.identity;
                Arrowabove.SetActive(false);
                Arrowleft.SetActive(true);
                Arrowright.SetActive(true);
                Arrowbelow.SetActive(true);
                break;

            // Si se hace click en la flecha izquierda entonces
            case 2:
                PositionWayPoint = ListWayPoints[2];
                RotationWayPoint = Quaternion.Euler(0, -90, 0);
                Arrowabove.SetActive(false);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);

                break;

            // Si se hace click en la flecha derecha entonces
            case -1:
                PositionWayPoint = ListWayPoints[3];
                RotationWayPoint = Quaternion.Euler(0, 90, 0);
                Arrowabove.SetActive(false);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);
                Arrowbelow.SetActive(true);

                break;

            // Si se hace click en la flecha abajo si estas en la flecha derecha entonces
            case -2:
                // Si el click es menor que -2 entonces que vuelva a 0
                WayPointsClick = 1;

                break;

            
        }


        Player.transform.position = Vector3.Lerp(Player.transform.position, PositionWayPoint.transform.position, Speed * Time.deltaTime);
        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, RotationWayPoint, Speed * Time.deltaTime);
    }





    // Si se hace click en la flecha arriba
    public void OnClickAbove()
    {
        // sube el contador click
        WayPointsClick++;

    }


    // Si se hace click en la flecha izquierda
    public void OnClickLeft()
    {
        // sube el contador click
        WayPointsClick++;

    }

    // Si se hace click en la flecha derecha
    public void OnClickRight()
    {
        // baja el contador click a -1 esto ocurre para que el click no suba y vaya en el contador -1
        WayPointsClick = -1;

    }

    // Si se hace click en la flecha abajo
    public void OnClickBelow()
    {
        // baja el contador click
        WayPointsClick--;


    }

}