using Fungus;
using UnityEngine;

namespace BotCutSceneMovement.BotScript
{
    public class SceneTrigger : MonoBehaviour {
        
        bool EnteredTheRoom;
        public GameObject Player;
        public Flowchart Flowchart;

        private void OnTriggerEnter(Collider other)
        {
            if (other == Player.GetComponent<Collider>())
            {
                EnteredTheRoom = true;
                Debug.Log(gameObject.name);
                Flowchart.SendFungusMessage(gameObject.name);
            }
        }

   
    
    }
}
