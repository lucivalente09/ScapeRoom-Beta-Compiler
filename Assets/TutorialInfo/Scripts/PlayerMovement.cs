using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Arrowabove;
    [SerializeField] GameObject Arrowleft;
    [SerializeField] GameObject Arrowright;
    [SerializeField] GameObject Arrowbelow;
    [SerializeField] GameObject[] ListWayPoints;


    [SerializeField] int click = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arrowleft.SetActive(false);
        Arrowright.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (click)
        {

            // Si se vuelve atras o sea click = 0 entonces
            case 0:
                Player.transform.position = Vector3.Lerp(Player.transform.position, ListWayPoints[0].transform.position, Speed * Time.deltaTime);

                Arrowabove.SetActive(true);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);
                Arrowbelow.SetActive(false);
                break;

            // Si se hace click en la flacha de arriba entonces 
            case 1:

                Player.transform.position = Vector3.Lerp(Player.transform.position, ListWayPoints[1].transform.position, Speed * Time.deltaTime);
                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.identity, Speed * Time.deltaTime);

                Player.transform.position = Vector3.Lerp(Player.transform.position, ListWayPoints[1].transform.position, Speed * Time.deltaTime);
                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation,  Quaternion.identity, Speed * Time.deltaTime);

                Arrowabove.SetActive(false);
                Arrowleft.SetActive(true);
                Arrowright.SetActive(true);
                Arrowbelow.SetActive(true);
                break;


            // Si se hace click en la flecha izquierda entonces
            case 2:

                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, -90, 0), Speed * Time.deltaTime);

                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, -90, 0), Speed * Time.deltaTime);

                Arrowabove.SetActive(false);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);
                Player.transform.position = Vector3.Lerp(Player.transform.position, ListWayPoints[2].transform.position, Speed * Time.deltaTime);
                break;

            // Si se hace click en la flecha derecha entonces
            case -1:
                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, 90, 0), Speed * Time.deltaTime);

                Arrowabove.SetActive(false);
                Arrowleft.SetActive(false);
                Arrowright.SetActive(false);
                Arrowbelow.SetActive(true);
                Player.transform.position = Vector3.Lerp(Player.transform.position, ListWayPoints[3].transform.position, Speed * Time.deltaTime);
                break;

            // Si se hace click en la flecha abajo si estas en la flecha derecha entonces
            case -2:
                click = 1;
                break;
        }

        // Si el click es menor que -2 entonces que vuelva a 0
        Mathf.Clamp(click, -2, 2);
    }


    // Si se hace click en la flecha arriba
    public void OnMouseDownAbove()
    {
        // sube el contador click
        click++;

    }


    // Si se hace click en la flecha izquierda
    public void OnMouseDownLeft()
    {
        // sube el contador click
        click++;

    }

    // Si se hace click en la flecha derecha
    public void OnMouseDownRight()
    {
        // baja el contador click a -1 esto ocurre para que el click no suba y vaya en el contador -1
        click = -1;

    }

    // Si se hace click en la flecha abajo
    public void OnMouseDownBelow()
    {
        // baja el contador click
        click--;


    }




}
