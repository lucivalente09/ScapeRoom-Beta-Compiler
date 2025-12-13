using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class PuzzlesEmpty : Puzzles
{

    [SerializeField] Renderer[] PuzzleRendererList;
    

    [SerializeField] public int PuzzleCount;

    [SerializeField] Renderer[] LightGreenList;

    [SerializeField] int completed = 0;
    public Light[] LightGreen;

    [SerializeField] float Speed;

    bool isCounter = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Completed empieza en -1 porque al completar el primer puzzle se suma 1 y queda en 0, que es el primer indice del array LightGreenList
        completed = -1;
        LightGreen[0].enabled = false;
        LightGreen[1].enabled = false;
        LightGreen[2].enabled = false;


    }


    // Update is called once per frame
    private void Update()
    {

        if (PuzzleCount == 6 && !isCounter)
        {
            Debug.Log("Puzzle_Completed!");
            completed++;
            isCounter = true;
            if (completed < LightGreenList.Length)
            {
                LightGreenList[completed].material.color = Color.green;
                LightGreenList[completed].name = "LightGreen_On";
                LightGreen[completed].enabled = true;
            }

            StartCoroutine(ColorsDetected());
       }


        //Completed es 2 y no 3 ya que hay 3 puzzles (0,1,2)
        if (completed == 2)
        {

            Debug.Log("All_Puzzles1_Completed!");
            GameObject Base = GetComponent<Transform>().parent.gameObject;
            Base.AddComponent<Rigidbody>();
            Console.Clear();


        }

    }

    IEnumerator ColorsDetected()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer renderer in PuzzleRendererList)
        {
           isCounter = false;
           renderer.material.color = ColorsAct_Des[0];
        }
        StopCoroutine(ColorsDetected());

    }

    

}
