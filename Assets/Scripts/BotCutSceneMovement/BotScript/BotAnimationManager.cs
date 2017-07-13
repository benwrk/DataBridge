using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BotAnimationManager : MonoBehaviour {

    RigidbodyFirstPersonController controller;
    bool Freeze;

    Animator BotAnimator;

    // Use this for initialization
    void Start () {

        BotAnimator = GetComponent<GameObject>().GetComponent<Animator>();
        Freeze = BotAnimator.GetBool("frozen");
        
		
	}



    void ToggleFreezeOfPlayer(bool freeze)
    {


        controller.GetComponent<PlayerController>().isFrozen = !freeze;
    }




}
