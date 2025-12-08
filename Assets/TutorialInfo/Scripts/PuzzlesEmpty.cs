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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }


    // Update is called once per frame
    private void Update()
    {
        if (PuzzleCount == 6 && completed == 0)

        {

            Debug.Log("Puzzle_Completed!");
            completed++;
            StartCoroutine(ColorsDetected());


        }

        if (PuzzleCount == 12 && completed == 1)

        {

            Debug.Log("Puzzle_Completed_1!");
            completed++;
            StartCoroutine(ColorsDetected());

        }

        if (PuzzleCount == 18 && completed == 2)

        {
           
            Debug.Log("Puzzle_Completed_2!");
            completed++;
            StartCoroutine(ColorsDetected());


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
