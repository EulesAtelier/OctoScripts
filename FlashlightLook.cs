using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLook : MonoBehaviour
{
    public GrabbableItem GI;
    void Update()
    {
        if(GI.isBeingHeld){RotateTowardsTarget();}
    }
    void RotateTowardsTarget(){
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition)-this.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
    }
}
