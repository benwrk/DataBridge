using UnityEngine;

public class BotAnimationManager : MonoBehaviour
{
    public GameObject controller;

    private bool AnimatorFreeze;

    private Animator BotAnimator;
    private bool gravity;


    // Use this for initialization
    private void Start()
    {
        GameStates.FloatingObjectsEnabled = true;
        BotAnimator = GetComponent<Animator>();
        AnimatorFreeze = BotAnimator.GetBool("frozen");
        ToggleFreezeOfPlayer(AnimatorFreeze);
    }


    private void ToggleFreezeOfPlayer(bool freeze)
    {
        controller.GetComponent<PlayerController>().ToggleFreeze();

        AnimatorFreeze =
            controller.GetComponent<PlayerController>()
                .IsFrozen; //TODO remove this if not conflicting  with the notmal toggle of the player in´´during the gameplay
    }
}