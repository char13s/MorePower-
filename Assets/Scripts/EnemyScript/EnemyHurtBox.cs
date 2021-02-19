using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    [SerializeField] private EnemyBasics enemy;
    [SerializeField] private GameObject splat;
    private PlayerInputs player;

    public EnemyBasics Enemy { get => enemy; set => enemy = value; }

    // Start is called before the first frame update
    void Start()
    {
        player=PlayerInputs.GetPlayer();
    }
    private void OnTriggerEnter(Collider collision) {
        Debug.Log("hit");
        //Enemy.Health -= player.Stats.Attack;
        if (enemy.Defense > 0) {
            Enemy.Defense -= player.Stats.Attack;
        }
        else {
            Enemy.Health -= player.Stats.Attack;
        }
        Debug.Log(Enemy.Health);
        Instantiate(splat,transform.position,Quaternion.identity);
    }
}
