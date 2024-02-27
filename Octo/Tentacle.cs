using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public LineRenderer lineRend;
    public Transform[] points;
    public void SetUpLine(Transform[] points){
        lineRend.positionCount = points.Length;
        this.points = points;
    }
    // Update is called once per frame
    private void Update()
    {
        for(int i = 0; i < points.Length; i++){
            lineRend.SetPosition(i,points[i].position);
        }
        
    }
}
