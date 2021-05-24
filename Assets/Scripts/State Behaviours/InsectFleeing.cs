using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GnomeGardeners
{
	public class InsectFleeing : StateMachineBehaviour
	{
		public Insect insect;


		private readonly int isFleeingHash = Animator.StringToHash("IsFleeing");

	    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	    {
			insect.SetTargetToExit();
	    }

	    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	    {
			var hasExited = insect.MoveToTarget();
			if(hasExited)
				animator.SetBool(isFleeingHash, false);
	    }


	    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	    {
			insect.Despawn();
	    }

	    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	    //{
	    //    // Implement code that processes and affects root motion
	    //}

	    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	    //{
	    //    // Implement code that sets up animation IK (inverse kinematics)
	    //}
	}
}