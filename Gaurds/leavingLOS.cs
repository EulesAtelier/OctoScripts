using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leavingLOS : MonoBehaviour
{
    public GaurdAI gAI;
    public void OnTriggerStay(Collider col){
        if(col.tag == "body"){
            gAI.spotted = true;
            gAI.lastSeenLocation = col.gameObject.transform.position;
        }
    }
    public void OnTriggerExit(Collider col){
        if(col.tag == "body"){
            gAI.spotted = false;
            gAI.lastSeenLocation = col.gameObject.transform.position;
        }
    }
}
