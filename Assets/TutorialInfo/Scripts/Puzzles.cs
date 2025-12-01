using System.Collections;
using System.Linq;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [SerializeField] Renderer PuzzleRenderer;
    [SerializeField] Renderer[] PuzzleRendererList;
    [SerializeField] Color[] ColorsAct_Des;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PuzzleRenderer.material.color = ColorsAct_Des[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
       PuzzleRenderer.material.color = ColorsAct_Des[1];
            StartCoroutine(ChangeColorBack());

    }

    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(1);
        PuzzleRenderer.material.color = ColorsAct_Des[0];
    }
}

