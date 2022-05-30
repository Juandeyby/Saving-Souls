using System;
using TMPro;
using UnityEngine;

namespace Game.Code
{
    public class UILevelScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text score;
        [SerializeField] private GameObject nextButton;
        [SerializeField] private GameObject resetButton;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnClickAgain()
        {
            Singleton.Instance.AgainLevel();
        }

        public void OnClickNext()
        {
            Singleton.Instance.NextLevel();
        }

        public void OnClickReset()
        {
            Singleton.Instance.ResetAll();
        }

        public void ActivatePanel(int currentTime)
        {
            if (Singleton.Instance.IsLastLevel())
            {
                nextButton.SetActive(false);
                resetButton.SetActive(true);
            }
            else
            {
                nextButton.SetActive(true);
                resetButton.SetActive(false);
            }
            score.text = $"{currentTime / 60}:" + (currentTime % 60).ToString("00");
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
        }

        public void DeactivatePanel()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
        }
    }
}
