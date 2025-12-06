using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class PuzzlesEmpty : Puzzles
{

    public List<Renderer> PuzzleRendererList = new List<Renderer>();
    [SerializeField] public int PuzzleCount = 0;
    public Renderer[] LightGreenArray;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        if (PuzzleCount == 6)
        {
            Debug.Log("Puzzle Completed!");

            
        }

        else
        {
            Debug.Log(null);

        }

    }
}
