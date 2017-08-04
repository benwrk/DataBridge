using UnityEngine;

namespace BotCutSceneMovement.BotScript
{
    public class BotAnimationManager : MonoBehaviour
    {
        private bool _animatorFreeze;
        private Animator _botAnimator;
        public GameObject Controller;
       // private bool _gravity;
        //public
        
        // Use this for initialization
        private void Start()
        {
            GameStates.FloatingObjectsEnabled = true;
            _botAnimator = GetComponent<Animator>();
            _animatorFreeze = _botAnimator.GetBool("frozen");
           // ToggleFreezeOfPlayer(_animatorFreeze);
        }

        private void ToggleFreezeOfPlayer(bool freeze)
        {
            Controller.GetComponent<PlayerController>().ToggleFreeze();
            _animatorFreeze =Controller.GetComponent<PlayerController>().IsFrozen; //TODO remove this if not conflicting  with the notmal toggle of the player in´´during the gameplay
        }

        private void FixedUpdate()
        {
            
        }
    }
}