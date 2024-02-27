using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevelLocation : endLevelMaster
{
    public bool conditionMet = false;
    public SceneChange SC;
    void OnTriggerEnter2D(Collider2D col){
        if(conditionMet && col.tag == "Octopus"){
            SC.ChangeScene("LevelSelect");
        }
    }
    
}
