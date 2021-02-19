using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StatsEnhancer : MonoBehaviour
{
    public static event UnityAction<int> boostAtt;
    public static event UnityAction<int> boostDef;
    public static event UnityAction<int> boostMp;
    [SerializeField] private Text attackText;
    [SerializeField] private Text defenseText;
    [SerializeField] private Text mpText;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int mp;


    public int Attack {
        get => attack; set {
            attack = (int)Mathf.Clamp(value, 0, 9999999999);
            attackText.text = attack.ToString();
            if (boostAtt != null) {
                boostAtt(attack);
            }
        }
    }
    public int Defense { get => defense; set { defense = value; } }
    public int Mp { get => mp; set { mp = value; } }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void AttackControl(int val) {
        Attack += val;
    }
    public void DefenseControl(int val) {
        Defense += val;
    }
    public void MpControl(int val) {
        Mp += val;
    }
}
