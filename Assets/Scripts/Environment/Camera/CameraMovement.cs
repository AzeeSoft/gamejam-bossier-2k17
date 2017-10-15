using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camOffsetX;
    public float camOffsetY;

    GameObject pecky;
    Camera camera;
    float initOffsetX;
    float initOffsetY;


    // Use this for initialization
    void Start()
    {
        pecky = GameObject.FindGameObjectWithTag("pecky");
        camera = GetComponent<Camera>();

        alignWithPlayer();
        initOffsetX = transform.position.x - pecky.transform.position.x;
        initOffsetY = transform.position.y - pecky.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    void updatePosition()
    {
        if (pecky != null)
        {
            Vector3 pos = transform.position;
            pos.x = pecky.transform.position.x + initOffsetX;
            PeckyMovement peckyMovement = pecky.GetComponent<PeckyMovement>();
            if (peckyMovement.isGrounded)
            {
                pos.y = pecky.transform.position.y + initOffsetY;
            }
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime*2);
        }
    }

    void alignWithPlayer()
    {
        Vector2 camBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0));
        float targetX = pecky.transform.position.x - camOffsetX;
        float targetY = pecky.transform.position.y - camOffsetY;

        float diffX = camBottomLeft.x - targetX;
        float diffY = camBottomLeft.y - targetY;

        Vector3 pos = transform.position;
        pos.x -= diffX;
        pos.y -= diffY;
        transform.position = pos;

    }
}