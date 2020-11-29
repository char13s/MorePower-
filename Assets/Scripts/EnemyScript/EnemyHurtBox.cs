using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    [SerializeField] private EnemyBasics enemy;
    private PlayerInputs player;

    public EnemyBasics Enemy { get => enemy; set => enemy = value; }

    // Start is called before the first frame update
    void Start()
    {
        player=PlayerInputs.GetPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("hit");
        Enemy.Health -= player.Attack;
        Debug.Log(Enemy.Health);
    }
}
