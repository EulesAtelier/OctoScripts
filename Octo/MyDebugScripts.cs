using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDebugScripts : MonoBehaviour
{
    public Rigidbody [] tips;
    public GameObject body;
    public Rigidbody bodyBody;
    public float force;
    public Camera cam;
    public int current;
    public Material normal;
    public Material emissive;
    private int previous;
    public GameObject heldItem = null;
    public bool isHolding;
    public bool useAll;
    public LayerMask worldLayer;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            useAll = !useAll;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            for(int i = 0; i < tips.Length;i++){
                tips[i].constraints = RigidbodyConstraints.None;
            }
        }
        GetPressedNumber();
        Move();
    }
    public void GetPressedNumber() {
        for (int number = 0; number <= 8; number++) {
            if (Input.GetKeyDown(number.ToString()) && current !=number-1){
                tips[current].gameObject.GetComponent<MeshRenderer> ().material = normal;
                current = number-1;
                Debug.Log(current);
                tips[current].gameObject.GetComponent<MeshRenderer> ().material = emissive;
            }
        }
    }

    void Move(){
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButton(1)){
                tips[current].constraints = RigidbodyConstraints.None;
                if (Physics.Raycast(ray, out hit, worldLayer)) {
                    Vector3 targetDirection = hit.point - tips[current].gameObject.transform.position;
                    if(hit.point.y-body.transform.position.y > 0.1){
                        Vector3 upForce = new Vector3(0,1,0);
                        bodyBody.AddForce(upForce*force);
                        tips[current].AddForce(upForce*force);
                    }
                    else if(hit.point.y-tips[current].gameObject.transform.position.y > 0.5){
                        Vector3 upForce = new Vector3(0,5,0);
                        bodyBody.AddForce(upForce*force);
                    }
                    if(useAll){
                        for(int i = 0; i < tips.Length;i++){
                            tips[i].AddForce(targetDirection*5);
                        }
                    }else{
                        tips[current].AddForce(targetDirection*5);
                    }                
                }
            }else if(Input.GetMouseButtonDown(0)){
                if(isHolding){
                    isHolding = false;
                    tips[current].gameObject.transform.DetachChildren();
                    if(heldItem.GetComponent<Rigidbody>()==false)
                        heldItem.AddComponent<Rigidbody>(); 
                }else if(!(isHolding) && heldItem == null){
                    tips[current].constraints = RigidbodyConstraints.FreezeAll;
                }else{
                    if(heldItem.GetComponent<Rigidbody>()==true)
                        Destroy(heldItem.GetComponent<Rigidbody>());
                    heldItem.transform.SetParent(tips[current].gameObject.transform);
                    isHolding = true;
                }
            }
    }
}
