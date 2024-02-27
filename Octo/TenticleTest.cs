using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenticleTest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Tentacle ten;
    
    // Start is called before the first frame update
    private void Start()
    {
        ten.SetUpLine(points);
    }
}
