using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChainInputs : StateMachineBehaviour
{
    public static event UnityAction<int> chainReset;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (chainReset != null) {
            chainReset(0);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (chainReset != null) {
            chainReset(0);
        }
    }
}
