using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionScript : MonoBehaviour
{
    public GaurdAI gAI;
    public bool sightLine = true;
    public void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Octopus"){
            Debug.Log("FOUND YOU");
            gAI.spotted = true;
            if(sightLine){
                gAI.lastSeenLocation = col.gameObject.transform.position;
            }
        }
    }
}
