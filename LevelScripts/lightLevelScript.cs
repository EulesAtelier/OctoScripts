using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class lightLevelScript : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D levelLight; 
    public GameObject thoughts;
    public bool off;
    public endLevelLocation ELL;
    public float lightLevel;
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Rock"){
            //PlayParticle
            levelLight.intensity = lightLevel;
            ELL.conditionMet = true;
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
