using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class shrimpLevelScript : MonoBehaviour
{
    public GameObject thoughts;
    public endLevelLocation ELL;
    public int numberOfShrimps = 0;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Rock"){
            //PlayParticle
            numberOfShrimps++;
            if(numberOfShrimps >= 3){
                ELL.conditionMet = true;
            }
            StartCoroutine(ShowThoughts());
        }
    }
    IEnumerator ShowThoughts(){
        yield return new WaitForSeconds(3.0f);
        thoughts.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        thoughts.SetActive(false);
    }
}
