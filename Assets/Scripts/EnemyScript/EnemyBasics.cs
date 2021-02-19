using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyBasics : MonoBehaviour {
    private enum Tiers {Low, Mid, High }
    #region anim parameters
    private bool walk;
    private bool hit;
    private bool dead;
    #endregion
    private Coroutine slowUpdate;
    [SerializeField] private float attackDelay;

    #region Outside obj refs
    [SerializeField] private GameObject hitBox;
    #endregion

    #region stats
    private float health;
    [SerializeField] private Tiers tier;
    [SerializeField] private float speed;
    [SerializeField] private float attackPower;
    [SerializeField] private float defense;
    #endregion

    #region Events
    public static event UnityAction<int> sendOrbs;
    #endregion
    
    private PlayerInputs player;

    public float Health { get => health; set { health = Mathf.Clamp(value, 0, 9999);HealthCheck(); } }
    public bool Walk { get => walk; set => walk = value; }
    public bool Dead { get => dead; set { dead = value; if (value) { DeadControl(); } } }
    public bool Hit { get => hit; set => hit = value; }
    public float AttackDelay { get => attackDelay; set => attackDelay = Mathf.Clamp(value,0,999); }
    public float AttackPower { get => attackPower; set => attackPower = value; }
    public float Defense { get => defense; set => defense = value; }

    private float Distance() => Vector2.Distance(transform.position, player.transform.position);
    // Start is called before the first frame update
    private void Awake() {
        Health = 10;
    }
    void Start() {
        player = PlayerInputs.GetPlayer();
        //slowUpdate = StartCoroutine(SlowUpdate());
    }

    // Update is called once per frame
    void Update() {
        if (Distance() > 5f&&!hit) {
            Follow();
        }
    }
    private void FakeUpdate() {
        
        if (Distance() < 0.45f&&!hit) {
            AttackState();
        }
    }
    private void AttackState() {
        if (AttackDelay == 0) {
            StartCoroutine(WaitToAttack());
        }
        else {
            StartCoroutine(WaitForAttackDelay());
        }
    }
    private void Follow() {
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
    }
    #region Helper Methods
    private void HealthCheck() {
        if (health == 0&&!dead) {
            Dead = true;
        }
    }
    private void DeadControl() {
        SendOrbs();
        Destroy(gameObject,4);
    }
    private void SendOrbs() {
        switch (tier) {
            case Tiers.Low:
                if (sendOrbs != null) {
                    sendOrbs(150);
                }
                break;
            case Tiers.Mid:
                if (sendOrbs != null) {
                    sendOrbs(500);
                }
                break;
            case Tiers.High:
                if (sendOrbs != null) {
                    sendOrbs(1500);
                }
                break;
        }
    }
    private void OnHit() {
        AttackDelay = 5;
    }
    #endregion
    #region coroutines
    private IEnumerator DisableHitbox() {
        YieldInstruction wait = new WaitForSeconds(0.35f);
        yield return wait;
        hitBox.SetActive(false);
    }
    private IEnumerator WaitToAttack() {
        YieldInstruction wait = new WaitForSeconds(0.1f);
        yield return wait;
        hitBox.SetActive(true);
        AttackDelay = 2;
        StartCoroutine(DisableHitbox());
    }
    private IEnumerator WaitForAttackDelay() {
        YieldInstruction wait = new WaitForSeconds(1);
        yield return wait;
        AttackDelay--;
    }
    private IEnumerator SlowUpdate() {
        YieldInstruction wait = new WaitForSeconds(1);
        while (isActiveAndEnabled) { 
        yield return wait;
        FakeUpdate();
        }
    }
        #endregion
}
