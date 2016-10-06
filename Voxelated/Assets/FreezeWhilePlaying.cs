using UnityEngine;
using System.Collections;

public class FreezeWhilePlaying : StateMachineBehaviour {
    public GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        player.GetComponent<CharacterScript>().Freeze();
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.GetComponent<CharacterScript>().Freeze();
    }
}
