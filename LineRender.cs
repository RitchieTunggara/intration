using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private LineController line;
    // private 
    // Start is called before the first frame update
    private void Start()
    {
        line.SetUpLine(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
