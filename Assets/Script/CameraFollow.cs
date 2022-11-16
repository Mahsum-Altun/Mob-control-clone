using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float speed = 5;
    public Vector3 offset;
    //Add kinematic Rigidbody for camera shake
    private Rigidbody rb;

    private void Start()
    {
        //Get the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var newRotation = Quaternion.LookRotation(target.transform.position - rb.position + Vector3.zero);
        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, speed * Time.deltaTime);
        Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
        rb.position = Vector3.Slerp(rb.position, newPosition, Time.deltaTime * speed);
    }
}
