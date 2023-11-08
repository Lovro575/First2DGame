using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private GameObject camera;

    //from CameraFollow script
    public Transform playerTransform;
    public Vector3 offset;
    
    private void Start() 
    { 
        //camera = GameObject.Find("Main Camera");
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    
    // Update is called once per frame
    /* private void Update()
    {
        if (transform.position.x >= playerPosition.position.x + 10.94f)
        {
            playerPosition.position = new Vector2(playerPosition.position.x, transform.position.y - 10.94f);
        }
    } */

    private void LateUpdate()
    {
        //from CameraFollow script
        transform.position = new Vector3 (playerTransform.position.x + offset.x, offset.y, offset.z);
        transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y);

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        //NEW
         if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3 (cameraTransform.position.x + offsetPositionX, transform.position.y);
        } 
    }
}
