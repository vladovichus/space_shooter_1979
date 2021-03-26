using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    private float shipBoundaryRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //rotate ship

        //rottaion quaternion
        Quaternion rot = transform.rotation;

        //z euler angle
        float z = rot.eulerAngles.z;

        //change z angle base on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, 0, z);

        //move ship
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        // camera's boundaries
        // vertical first
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        // calculate orthographic width based on screen ratio 
        float screenRatio = (float) Screen.width / (float) Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //horizontal bounds
        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }

        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        // update position
        transform.position = pos;
    }
}