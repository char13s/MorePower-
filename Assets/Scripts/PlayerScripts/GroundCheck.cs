using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GroundCheck : MonoBehaviour
{
    public static event UnityAction<bool> grounded;
    private float distanceGround;
    private PlayerInputs player;
    private void Start() {
        distanceGround = GetComponent<Collider>().bounds.extents.y;
        player = PlayerInputs.GetPlayer();
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (grounded != null) {
    //        grounded(true);
    //    }
    //}
    ////private void OnTriggerStay(Collider other) {
    ////    if (grounded != null) {
    ////        grounded(true);
    ////    }
    ////    
    ////}
    //private void OnTriggerExit(Collider other) {
    //    if (grounded != null) {
    //        grounded(false);
    //    }
    //}
    private void FixedUpdate() {
        if (!Physics.Raycast(transform.position, -Vector2.up, distanceGround + 0.12f)) {
            player.IsGrounded = false;

        }
        else { 
            player.IsGrounded = true;

        }
    }
}