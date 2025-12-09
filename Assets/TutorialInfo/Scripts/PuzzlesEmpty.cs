using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class PuzzlesEmpty : Puzzles
{

    public List<Renderer> PuzzleRendererList = new List<Renderer>();
    [SerializeField] public int PuzzleCount;

    public Renderer[] LightGreenArray;
    [SerializeField] int completed = 0;
    public Light[] LightGreen;

    [SerializeField] float Speed;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       LightGreen[0].enabled = false;
       LightGreen[1].enabled = false;
       LightGreen[2].enabled = false;
      

    }


    // Update is called once per frame
    private void Update()
    {
        if (PuzzleCount == 6 && completed == 0)

        {

            Debug.Log("Puzzle_Completed!");
            completed++;
            LightGreenArray[0].material.color = Color.green;
            LightGreen[0].name = "GreenLightOn";
            LightGreen[0].enabled = true;
            StartCoroutine(ColorsDetected());


        }

        if (PuzzleCount == 12 && completed == 1)

        {

            Debug.Log("Puzzle_Completed_1!");
            completed++;
            LightGreenArray[1].material.color = Color.green;
            LightGreen[1].name = "GreenLightOn(1)";
            LightGreen[1].enabled = true;
            StartCoroutine(ColorsDetected());

        }

        if (PuzzleCount == 18 && completed == 2)

        {
           
            Debug.Log("Puzzle_Completed_2!");
            completed++;
            LightGreenArray[2].material.color = Color.green;
            LightGreen[2].name = "GreenLightOn(2)";
            LightGreen[2].enabled = true;
            StartCoroutine(ColorsDetected());


        }

        if (completed == 3)
        {

            Debug.Log("All_Puzzles1_Completed!");
            GameObject gameObject = GetComponent<Transform>().parent.gameObject;
            gameObject.AddComponent<Rigidbody>();


        }
    }

    IEnumerator ColorsDetected()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer renderer in PuzzleRendererList)
        {
            renderer.material.color = ColorsAct_Des[0];
        }
        StopCoroutine(ColorsDetected());

    }
}
