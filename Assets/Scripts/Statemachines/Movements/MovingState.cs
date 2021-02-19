using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MovingState : StateMachineBehaviour
{
    public static event UnityAction run;
    [SerializeField] private float moveSpeed;
    private Vector3 speed;
    private PlayerInputs player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = PlayerInputs.GetPlayer();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        ///player.Rbody.velocity = new Vector3(0, 0, player.Direction.z * moveSpeed);
        speed = new Vector3(0, 0, player.Direction.z * moveSpeed);
        speed.y = player.Rbody.velocity.y;
        player.Rbody.velocity = speed;

        //if (run != null) {
        //    run();
        //}
        //player.transform.position += new Vector3(0, 0, player.Direction.z * moveSpeed * Time.deltaTime) ;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //player.Rbody.velocity = Vector3.zero;
    }
}
