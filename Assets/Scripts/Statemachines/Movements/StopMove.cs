using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMove : StateMachineBehaviour
{
    PlayerInputs player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player=PlayerInputs.GetPlayer();
        player.Rbody.velocity = Vector3.zero;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = PlayerInputs.GetPlayer();
        player.Rbody.velocity = Vector3.zero;
    }
}
