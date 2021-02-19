using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackState : StateMachineBehaviour
{
    private PlayerInputs player; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = PlayerInputs.GetPlayer();
    }
    
}
