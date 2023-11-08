using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    //private Vector3 initialRotation;

    /* private void Awake()
    {
        //initialRotation = transform.eulerAngles;
    } */

    void Update() 
    {
        transform.position = new Vector3 (playerTransform.position.x + offset.x, offset.y, offset.z);

        //transform.position = new Vector2(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y);
        //transform.eulerAngles = new Vector2(playerTransform.eulerAngles.x + initialRotation.x, playerTransform.eulerAngles.y + initialRotation.y);
    }
}
