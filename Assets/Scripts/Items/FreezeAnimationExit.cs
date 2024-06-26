using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FreezeAnimationExit : StateMachineBehaviour
{

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteRenderer spriteRenderer = animator.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer spriteRenderer = animator.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }
}