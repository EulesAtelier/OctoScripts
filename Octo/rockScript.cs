using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rockScript : GrabbableItem
{
    public bool thrown = false;
    public int throwingSpeed;
    public override void  OnTriggerEnter2D(Collider2D col){
        if(octopus.isHolding[octopus.current]==false && col.gameObject.tag == "Tentacle")
            octopus.heldItem[col.gameObject.GetComponent<TentacleInfo>().number] = this.gameObject;
        if(col.gameObject.tag == "Breakable" && thrown){
            Destroy(col.gameObject);
            thrown = false;
            //program a particle effect and coroutine for that
        }
        if(col.gameObject.tag == "Guard" && thrown){
            thrown = false;
            Debug.Log("OW");
            StartCoroutine(KnockLightOff(col));
        }
    }
    IEnumerator KnockLightOff(Collider2D col){
        col.gameObject.GetComponent<GaurdAI>().Flashlight.SetActive(false);
        col.gameObject.GetComponent<GaurdAI>().agent.speed = 0f;
        yield return new WaitForSeconds(3.0f);
        col.gameObject.GetComponent<GaurdAI>().Flashlight.SetActive(true);
        col.gameObject.GetComponent<GaurdAI>().agent.speed = 3.5f;
    }
    public override void OnTriggerExit2D(Collider2D col){
        if(!(octopus.isHolding[octopus.current])){
            octopus.heldItem[octopus.current] = null;
        }
        
    }
}
