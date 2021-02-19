using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public override float BaseAttack { get => base.BaseAttack; set { base.BaseAttack = value; } }
    // Start is called before the first frame update
    void Start()
    {
        StatsEnhancer.boostAtt += BoostAttack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartStats() {
        BaseAttack = 2;
        BaseDefense = 1;
        BaseHealth = 5;
        BaseMp = 4;
    }
    private void BoostAttack(int val) {
        Attack = BaseAttack+val;
    }
}
