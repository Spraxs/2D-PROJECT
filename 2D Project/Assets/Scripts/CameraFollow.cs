using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    private Vector2 velocity;


    public bool cameraSlide = false;

    public float smoothTimeYFollow;
    public float smoothTimeXFollow;

    public float smoothTimeYSlide;
    public float smoothTimeXSlide;
    public float maxDistanceXSlide = 5f;
    public float maxDistanceYSlide = 3f;
    public float distanceSlide = 0.1f;



    public GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {


        if (cameraSlide)
        {
            float minPosX = Mathf.SmoothDamp(transform.position.x, transform.position.x - distanceSlide, ref velocity.x, smoothTimeXSlide);
            float plusPosX = Mathf.SmoothDamp(transform.position.x, transform.position.x + distanceSlide, ref velocity.x, smoothTimeXSlide);

            float minPosY = Mathf.SmoothDamp(transform.position.y, transform.position.y - distanceSlide, ref velocity.y, smoothTimeXSlide);
            float plusPosY = Mathf.SmoothDamp(transform.position.y, transform.position.y + distanceSlide, ref velocity.y, smoothTimeXSlide);

            if (player.transform.position.x - transform.position.x > maxDistanceXSlide)
            {
                transform.position = new Vector3(plusPosX, transform.position.y, transform.position.z);
            }

            if (player.transform.position.x - transform.position.x < -maxDistanceXSlide)
            {
                transform.position = new Vector3(minPosX, transform.position.y, transform.position.z);
            }

            if (player.transform.position.y - transform.position.y > maxDistanceYSlide)
            {
                transform.position = new Vector3(transform.position.x, plusPosY, transform.position.z);
            }

            if (player.transform.position.y - transform.position.y < -maxDistanceYSlide)
            {
                transform.position = new Vector3(transform.position.x, minPosY, transform.position.z);
            }
        } else
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeXFollow);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeYFollow);

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
