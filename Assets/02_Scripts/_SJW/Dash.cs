using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*        PlayerMovement playermove = animator.gameObject.GetComponentInParent<PlayerMovement>();
                Player player = animator.gameObject.GetComponentInParent<Player>();

                playermove.playerCharacter.localPosition = Vector3.zero;
                animator.gameObject.GetComponentInParent<SkinnedMeshAfterImage>().enabled = false;
                playermove.agent.speed = player.Move_Speed;
                if (playermove.isMove)
                {
                    animator.SetTrigger("DoRun");
                    player.PlayerRun();
                }
                else
                {
                    animator.SetTrigger("DoIdle");
                    player.PlayerIdle();
                }*/


       // animator.gameObject.GetComponentInParent<Player>().DashEnd();

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
