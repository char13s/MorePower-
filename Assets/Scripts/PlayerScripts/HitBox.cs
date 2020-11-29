﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    private void OnEnable() {

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null) {
            //Debug.Log(knockBackStrength);
            Debug.Log("Smack");
            Vector2 direction = collision.transform.position - transform.position;
            rb.AddForce(direction.normalized * 50000, ForceMode2D.Impulse);
        }
    }
}
