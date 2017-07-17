using UnityEngine;

public class BotAnimationManager : MonoBehaviour
{
    public GameObject controller;

    bool AnimatorFreeze;

    Animator BotAnimator;
    bool gravity;


    // Use this for initialization
    void Start()
    {
        GameStates.FloatingObjectsEnabled = true;
        BotAnimator = GetComponent<Animator>();
        AnimatorFreeze = BotAnimator.GetBool("frozen");
        ToggleFreezeOfPlayer(AnimatorFreeze);
    }


    void ToggleFreezeOfPlayer(bool freeze)
    {
        //controller.GetComponent<PlayerController>().ToggleFreeze();

        AnimatorFreeze =
            controller.GetComponent<PlayerController>()
                .IsFrozen; //TODO remove this if not conflicting  with the notmal toggle of the player in´´during the gameplay
    }
}