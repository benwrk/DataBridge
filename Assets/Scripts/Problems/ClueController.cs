using UnityEngine;
using UnityEngine.UI;

namespace Problems
{
    public class ClueController : MonoBehaviour
    {
        public GameManager GameManager;
        public int ClueIndex;

        
        public Text ClueText;
        
    
        private void Start()
        {
            var clues = GameManager.Clues;
            ClueText.text = clues[ClueIndex-1].Text;
        }
    }
}
