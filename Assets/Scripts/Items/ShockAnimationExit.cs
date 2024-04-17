using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockAnimationExit : StateMachineBehaviour
{   

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer spriteRenderer = animator.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
}
