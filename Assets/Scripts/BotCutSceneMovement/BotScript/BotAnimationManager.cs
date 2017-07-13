using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BotAnimationManager : MonoBehaviour {

    RigidbodyFirstPersonController controller;
    bool AnimatorFreeze;

    Animator BotAnimator;

    // Use this for initialization
    void Start () {

        BotAnimator = GetComponent<GameObject>().GetComponent<Animator>();
        AnimatorFreeze = BotAnimator.GetBool("frozen");
        
		
	}



    void ToggleFreezeOfPlayer(bool freeze)
    {


        // controller.GetComponent<PlayerController>().isFrozen = freeze;
        if (freeze == true)
        {
            controller.GetComponent<PlayerController>().DisableMovements();
        }
        else if (freeze == false)
        {
            controller.GetComponent<PlayerController>().EnableMovements();
        }

        AnimatorFreeze = freeze;
    }




}
