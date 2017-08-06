using UnityEngine;

namespace BotCutSceneMovement.BotScript
{
    public class FirstSceneTrigger : MonoBehaviour {
        
        bool EnteredTheRoom;
        public GameObject Player;

        private void OnTriggerEnter(Collider other)
        {
            if (other == Player.GetComponent<Collider>())
                EnteredTheRoom= true;
        }

   
    
    }
}
