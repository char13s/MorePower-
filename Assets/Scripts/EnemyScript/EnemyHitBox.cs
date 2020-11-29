using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour {
    [SerializeField]private EnemyBasics enemy;

    public EnemyBasics Enemy { get => enemy; set => enemy = value; }

    //private void OnEnable() {
    //    Debug.Log("HOE");
    //}
    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null) {
            //Debug.Log(knockBackStrength);
            Debug.Log("Smack");
            Vector2 direction = collision.transform.position - transform.position;
            rb.AddForce(direction.normalized * 5, ForceMode2D.Impulse);
        }
    }
}
