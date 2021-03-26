using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    public float invulnPeriod = 0;

    float invulnTimer = 0;
    int correctLayer;
    float invulnAnimTimer = 0;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        //renderer on parent object, not for children
        spriteRend = GetComponent<SpriteRenderer>();
        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer");
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Triggered!");
        health--;
        invulnTimer = 0.5f;
        gameObject.layer = 10;
    }

    void Update()
    {
        invulnTimer = Mathf.Max(invulnTimer - Time.deltaTime, 0);
        spriteRend.enabled = invulnTimer % 0.1f < 0.05f;


        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}