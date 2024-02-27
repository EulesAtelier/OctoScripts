using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishLevelScript : MonoBehaviour
{
    public OctopusController octopus;
    public int threshhold = 5;
    public endLevelLocation ELL;
    void Update(){

        if(octopus.fishEaten >= threshhold){
            ELL.conditionMet = true;
        }
    }
}
