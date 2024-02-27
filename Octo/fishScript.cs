using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishScript : GrabbableItem
{
    public TMP_Text fishText;
    public override void OnTriggerEnter2D(Collider2D col){
        if(octopus.isHolding[octopus.current]==false && col.gameObject.tag == "Tentacle")
            octopus.heldItem[col.gameObject.GetComponent<TentacleInfo>().number] = this.gameObject;
        if(col.gameObject.tag == "Octopus"){
            Destroy(this.gameObject);
            octopus.fishEaten++;
            fishText.text = "Fish: "+octopus.fishEaten;
        }
    }
}
