using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.QA
{

    public class QAPuzzle : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] GameObject door;
        [SerializeField] Text attemptsText;
        [SerializeField] Text puzzleQuestionText;
        [SerializeField] InputField answerInput;
        [SerializeField] Button submitButton;
        public string question;
        public string answer;

        public int attemptsRemaining = 3;

        private void Awake()
        {
            submitButton.onClick.RemoveAllListeners();
            submitButton.onClick.AddListener(Hide);

            canvas.SetActive(false);
        }

        private void OnEnable()
        {
            Debug.Log("Puzzle ENabled");
            puzzleQuestionText.text = question;
            attemptsText.text = "Attempts Remaining : " + attemptsRemaining;

            canvas.SetActive(true);

            PlayerMovement.solvingPuzzle = true;
        }

        private void OnDisable()
        {
            PlayerMovement.solvingPuzzle = false;
            attemptsRemaining = 3;
        }

        public void Hide()
        {
            if (answerInput.text.Equals(answer, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Solved Puzzle Correctly");
                gameObject.SetActive(false);
                door.SetActive(false);
            } 
            else
            {
                answerInput.text = "";
                attemptsRemaining--;
                attemptsText.text = "Attempts Remaining : " + attemptsRemaining;

                if (attemptsRemaining == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }

    }
}
