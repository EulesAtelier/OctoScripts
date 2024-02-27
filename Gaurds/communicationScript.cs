using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class communicationScript : MonoBehaviour
{
    public void OnTriggerStay(Collider col){
        if(col.tag == "gaurd"){
            Debug.Log("Alert!");
            col.gameObject.GetComponent<GaurdAI>().spotted = true;
            col.gameObject.GetComponent<GaurdAI>().lastSeenLocation = col.gameObject.transform.position;
        }
    }
}
