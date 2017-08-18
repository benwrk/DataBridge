using UnityEngine;

namespace Puzzle
{
    public class PuzzleTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            GameStates.PuzzleTrigger = true;
            GameStates.FloatingObjectsEnabled = false;
        }
    }
}