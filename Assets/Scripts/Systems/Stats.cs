using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats :MonoBehaviour
{
    private float baseHealth;
    private float baseHealthLeft;
    private float baseAttack;
    private float baseDefense;
    private float baseMp;
    


    private float attack;
    private float defense;
    private float health;
    private float mp;
    public virtual float BaseHealth { get => baseHealth; set => baseHealth = value; }
    public virtual float BaseHealthLeft { get => baseHealthLeft; set => baseHealthLeft = value; }
    public virtual float BaseAttack { get => baseAttack; set => baseAttack = value; }
    public virtual float BaseDefense { get => baseDefense; set => baseDefense = value; }
    public virtual float BaseMp { get => baseMp; set => baseMp = value; }
    public virtual float Attack { get => attack; set => attack = value; }
    public virtual float Defense { get => defense; set => defense = value; }
    public virtual float Health { get => health; set => health = value; }
    public virtual float Mp { get => mp; set => mp = value; }
    
}
