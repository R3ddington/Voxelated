using UnityEngine;
using System.Collections;

public class KatanaAttack : StateMachineBehaviour {
    public GameObject katana;
    public GameObject player;
    public bool is1;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if(katana == null)
        {
            if (is1)
            {
                katana = GameObject.Find("KatanaPlayer1");
                player = GameObject.Find("Player1");
            }
            else
            {
                katana = GameObject.Find("KatanaPlayer2");
                player = GameObject.Find("Player2");
            }
        }
        katana.GetComponent<KatanaScript>().SetOn();
        player.GetComponent<CoopPlayerController>().KataCool();
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        katana.GetComponent<KatanaScript>().SetOff();
    }
}