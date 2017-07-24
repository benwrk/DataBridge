using UnityEngine;
using UnityEngine.UI;

namespace Problems
{
    public class AnswerController : MonoBehaviour {

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick()
        {
            _button.interactable = false;
        }

        public bool IsCorrect(Text text)
        {
            return text.CompareTag("IsCorrect");
        }
    }
}