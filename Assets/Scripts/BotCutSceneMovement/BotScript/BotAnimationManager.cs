using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BotAnimationManager : MonoBehaviour {

    public  GameObject controller;
   
    bool AnimatorFreeze;

    Animator BotAnimator;
    bool gravity;


    // Use this for initialization
    void Start () {


        GameStates.floatingObjectsEnabled = true;
        BotAnimator = GetComponent<Animator>();
        AnimatorFreeze = BotAnimator.GetBool("frozen");
        ToggleFreezeOfPlayer(AnimatorFreeze);
       
    }



    void ToggleFreezeOfPlayer(bool freeze)
    {

        

        controller.GetComponent<PlayerController>().toggleFreeze();
        
        AnimatorFreeze = controller.GetComponent<PlayerController>().isFrozen; //TODO remove this if not conflicting  with the notmal toggle of the player in´´during the gameplay






    }


    

}
