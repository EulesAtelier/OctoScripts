using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject guard;
    public Transform [] positions;
    public int posCount = 0;
    public bool spotted;
    public Vector2 lastSeenLocation;
    public GameObject exclimationMark;
    public detectionScript dS;
    public GameObject Flashlight;
    void Start(){
        agent.SetDestination(positions[posCount].position);
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
    }
    void Update()
    {   
        //var angle = Math.Atan2(y, x) * 180 / Math.PI;
        //var rotationVector = transform.rotation.eulerAngles;
        /*rotationVector.x = 0;
        rotationVector.y = 0;
        agent.gameObject.transform.rotation = Quaternion.Euler(rotationVector);*/
        
        Vector2 currentGaurdPosition = guard.transform.position;
        RotateTowardsTarget();
        GraphicsHandler();
        if(spotted){
            FollowOctopus(currentGaurdPosition);
        }else{
            NodeMovement(currentGaurdPosition);
        }
    }
    void RotateTowardsTarget(){
       // Quaternion rotation = Quaternion.LookRotation(agent.destination - guard.transform.position ,transform.TransformDirection(Vector3.up));
        //guard.transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w );  
        Vector3 dir = agent.destination - guard.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        guard.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
    }
    //Handles various graphics including exclimation point sprite
    void GraphicsHandler(){
        exclimationMark.SetActive(spotted);
        exclimationMark.transform.rotation = Quaternion.identity;
        exclimationMark.transform.position = guard.transform.position + new Vector3(0,1,0);
        if(!spotted){
           // StartCoroutine(lost);
        }
    }
   // IEnumerator lost(){
   //     lostMark.SetActive(true);
   // }
    //Casts a ray to where the Gaurd thinks the octopus is, telling the detection script whether it is in the gaurds line of sight.
    void TrackOctopusVisual(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastSeenLocation);
        Debug.DrawRay(transform.position, lastSeenLocation, Color.green);
        if(hit.collider.tag == "Octopus"){
            dS.sightLine=true;
        }
        if(hit.collider.tag == "Obstacle"){
            dS.sightLine = false;
        }
    }
    //Moves the guard between predetermined nodes on the map, allowing for designer flexibility
    void NodeMovement(Vector2 gaurdPosition){
        if(Mathf.Abs(positions[posCount].position.y-gaurdPosition.y) < 1.0f && Mathf.Abs(positions[posCount].position.x-gaurdPosition.x) < 1.0f){
                posCount++;
                 if(posCount >= positions.Length){
                    posCount = 0;
                }
        }
        agent.SetDestination(positions[posCount].position);
    }
    //Sets the guards priority to follow the octopus's last known location until it reaches it.
    void FollowOctopus(Vector2 gaurdPosition){
        agent.SetDestination(lastSeenLocation);
        if(Mathf.Abs(lastSeenLocation.y-gaurdPosition.y) < 1.0f && Mathf.Abs(lastSeenLocation.x-gaurdPosition.x) < 1.0f){
            spotted = false;
        }
        TrackOctopusVisual();
    }
}
/*
    GaurdAIPrimative:
    - Move to Nodes placed down.
    - If the player is spotted Move to its location.
    - - Cast Rays towards the player. If the ray hit something that is not the player, stop tracking location.
    - -
*/
