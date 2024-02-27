using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleInfo : MonoBehaviour
{
    public int number;
    public LineRenderer lr;
    public bool grown = false;
    public void Start(){
        lr = this.GetComponent<LineRenderer>();
    }
}
