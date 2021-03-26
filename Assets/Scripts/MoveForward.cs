﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float maxSpeed = 5f;
    
    void Update()
    {
        Vector3 pos = transform.position;
        
        Vector3 velocity = new Vector3(0,  maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;

    }
}
