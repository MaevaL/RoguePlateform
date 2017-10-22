﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Ground") || col.collider.CompareTag("Environment") || col.collider.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}