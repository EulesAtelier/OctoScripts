using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtDisplayScript : MonoBehaviour
{    
    public GameObject cloud;
    public GameObject thoughts;
    public GameObject thoughts2;
    public GameObject thoughts3;
    public bool lev1;
    public bool lev2;
    public bool lev3;
    public bool lev4;
    void Start(){
        if(lev1)
            StartCoroutine(ShowThoughts());
        else if(lev2)
            StartCoroutine(ShowThoughtsAndAnother());
    }
    IEnumerator ShowThoughts(){
        yield return new WaitForSeconds(3.0f);
        thoughts.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        thoughts.SetActive(false);
    }
    IEnumerator ShowThoughtsAndAnother(){
        yield return new WaitForSeconds(3.0f);
        cloud.SetActive(true);
        thoughts.SetActive(true);
        thoughts2.SetActive(false);
        thoughts3.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        thoughts2.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        thoughts.SetActive(false);
        thoughts2.SetActive(false);
        thoughts3.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        thoughts3.SetActive(false);
        cloud.SetActive(false);
    }

}
