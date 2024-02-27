using UnityEngine;
using System.Collections;

public class FixedCamera : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public float offset;
    void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y,offset), ref velocity, smoothTime);
    }
}
