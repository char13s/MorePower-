using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HurtBox : MonoBehaviour {
    public static event UnityAction<float> sendDmg;
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("ouch");
        
            if (sendDmg != null) {
                sendDmg(-collision.GetComponent<EnemyHitBox>().Enemy.AttackPower);
            }
        

    }

}
