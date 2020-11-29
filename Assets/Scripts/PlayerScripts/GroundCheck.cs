using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GroundCheck : MonoBehaviour {
    public static event UnityAction<bool> grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (grounded != null) {
            grounded(true);
        }
    }
}
