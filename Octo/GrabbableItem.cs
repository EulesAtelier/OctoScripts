using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GrabbableItem : MonoBehaviour
{
    public OctopusController octopus;
    public int holdingTentacle;
    public bool isBeingHeld;
    public virtual void OnTriggerEnter2D(Collider2D col){
        if(octopus.isHolding[octopus.current]==false && col.gameObject.tag == "Tentacle")
            octopus.heldItem[col.gameObject.GetComponent<TentacleInfo>().number] = this.gameObject;
    }
    public virtual void OnTriggerExit2D(Collider2D col){
        if(!(octopus.isHolding[octopus.current])){
            octopus.heldItem[octopus.current] = null;
        }
        
    }
}
