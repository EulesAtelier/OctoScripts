using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingScript : MonoBehaviour
{
    public GameObject CaughtScreen;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Octopus"){
            CaughtScreen.SetActive(true);
        Time.timeScale = 0;
        }
    }
}
