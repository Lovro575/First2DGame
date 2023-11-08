using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground2 : MonoBehaviour
{
    private float length;
    private float startpos;
    private GameObject camera;
    private Camera camera2;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        startpos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        //camera2 = gameObject.GetComponent<Camera>();
        //Debug.Log("Game Object: ", camera2);
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z); 

        if(temp > startpos + length)
        {
            startpos += length;
        } 
        else if(temp < startpos - length )
        {
            startpos -= length;
        } 
    }
}
