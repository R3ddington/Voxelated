using UnityEngine;
using System.Collections;

public class PlayerAnimationDetection : MonoBehaviour {
    Animator anim;
    public Transform target;

    void Start ()
    {
        anim = this.GetComponent<Animator>();
        if(anim == null)
        {
            print("WARNING, PlayerAnimation Detection has a null anim on" + " " + this.transform.name.ToString());
        }
    }
    void OnAnimatorIK(int layerIndex)
    {
        print("anim triggered");
        //anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
       // anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
    }
}