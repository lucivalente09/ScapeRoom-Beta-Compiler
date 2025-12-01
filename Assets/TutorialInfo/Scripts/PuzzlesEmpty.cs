using UnityEngine;

public class PuzzlesEmpty : MonoBehaviour
{
    [SerializeField] Renderer[] PuzzleRendererList;
    [SerializeField] Color[] ColorsAct_Des;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleRendererList[1&2].material.color == ColorsAct_Des[1])
        {
            Debug.Log("Solved");
        }
    }
}
