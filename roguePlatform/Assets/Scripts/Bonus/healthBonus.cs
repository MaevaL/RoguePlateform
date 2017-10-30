﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour {
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void SetBonus(int arg) {
        player.GetComponent<LifeController>().GainLife(arg);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Player")) {
            SetBonus(1);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.CompareTag("Player")) {
    //        SetBonus(1);
    //        Destroy(gameObject);
    //    }
    //}
}
