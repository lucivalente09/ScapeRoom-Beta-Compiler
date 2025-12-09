using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [SerializeField] protected Renderer PuzzleRenderer;

    [SerializeField] PuzzlesEmpty puzzlesEmpty;

    [SerializeField] protected Color[] ColorsAct_Des;
    bool isCount = false;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        PuzzleRenderer.material.color = ColorsAct_Des[0];
    }

    // Update is called once per frame
    private void Update()
    {
        puzzlesEmpty.PuzzleCount = Mathf.Abs(puzzlesEmpty.PuzzleCount);
        if (PuzzleRenderer.material.color == ColorsAct_Des[1] && isCount == false)
        {
            isCount = true;
            puzzlesEmpty.PuzzleCount++;
        }

        else if (PuzzleRenderer.material.color != ColorsAct_Des[1] && isCount )
        {
            isCount = false;

        }


    }

    public void OnMouseDown()
    {
        PuzzleRenderer.material.color = ColorsAct_Des[1];
    
    }




}

