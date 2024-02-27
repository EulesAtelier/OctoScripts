using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
   [Header("Octopus Body Compenents")]
    public GameObject body;
    public Rigidbody2D bodyBody;
    public Rigidbody2D [] tips;
    public bool useAll;
    [Header("Octopus Holding Compenents")]
    public int current;
    public GameObject [] heldItem;
    public bool [] isHolding;
    [Header("Octopus Play Data")]
    public int fishEaten = 0;
    public GameObject thoughtsCore;
    [Header("Debugger")]
    private string debugActivStrings = "DebugMovementMode Activated";
    private string debugDeActivStrings = "DebugMovementMode DeActivated";
    [SerializeField]
    private bool debugMode = false;

    void Update()
    {
        //contains debug mode, and which tentacle is being controller with mouse;
        GetPressedNumber();
        Move();
        HeldObjectPositionChange();
        thoughtsCore.transform.position = body.transform.position;
        //handling grabbing and throwing;
        if(Input.GetMouseButtonDown(0)){
            if(isHolding[current]){
                Throw();
            }else{
                Grab();
            }
        }
    }
    void HeldObjectPositionChange(){
        for(int i = 0; i < 8; i++){
            if(isHolding[i]==true){
                heldItem[i].transform.position = tips[i].gameObject.transform.position;
            }
        }
    }
    void Move(){
        if (Input.GetMouseButton(1)) {
            Vector2 targetDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition)-tips[current].gameObject.transform.position;
            if(useAll){
                for(int i = 0; i < tips.Length;i++){
                    tips[i].AddForce(targetDirection*5);
                }
            }else{
                tips[current].AddForce(targetDirection*5);
            }                
        }
    }
    void Throw(){
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetDirection = targetPosition-(Vector2)heldItem[current].transform.position;
        isHolding[current] = false;
        heldItem[current].GetComponent<CircleCollider2D>().enabled = (true);
        heldItem[current].GetComponent<CapsuleCollider2D>().enabled = (true);
        heldItem[current].GetComponent<GrabbableItem>().isBeingHeld = false;
        if(heldItem[current].tag == "Rock"){
            heldItem[current].GetComponent<rockScript>().thrown = true;
            Vector2 targetThrownDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition)-heldItem[current].gameObject.transform.position;
            heldItem[current].GetComponent<Rigidbody2D>().AddForce(targetThrownDirection * heldItem[current].GetComponent<rockScript>().throwingSpeed);
        }
    }
    void Grab(){
        Debug.Log("Grabbing");
        if(isHolding[current]!=true && heldItem[current]!=null){
            isHolding[current] = true;
            heldItem[current].GetComponent<GrabbableItem>().holdingTentacle = current;
            heldItem[current].GetComponent<CircleCollider2D>().enabled = (false);
            heldItem[current].GetComponent<CapsuleCollider2D>().enabled = (false);
            heldItem[current].GetComponent<GrabbableItem>().isBeingHeld = true;
        }        
    }
    void GetPressedNumber() {
        Debugging();
        for (int number = 0; number <= 8; number++) {
            if (Input.GetKeyDown(number.ToString()) && current !=number-1){
                current = number-1;
            }
        }
    }
    void Debugging(){
        if(Input.GetKeyDown(KeyCode.O)){
            debugMode = !debugMode;
            useAll = !useAll;
            if(debugMode)
                Debug.Log(debugActivStrings);
            else
                Debug.Log(debugDeActivStrings);
        }
    }
}


