using TMPro;
using UnityEngine;

namespace Game.Code
{
    public class UISingleton : MonoBehaviour
    {
        public static UISingleton Instance { get; private set; }
        [SerializeField] private UIObject uiObject;
        [SerializeField] private UITimer uiTimer;
        [SerializeField] private UILevelScore levelScore;
        [SerializeField] private TMP_Text levelTitle;
        [SerializeField] private CanvasGroup intro;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this);
                return;
            } 
            Instance = this;
        }

        public void UpRelic(int order)
        {
            uiObject.UpRelic(order);
        }

        public void StarGame()
        {
            SetLevelTile();
            uiTimer.StartTimer();
            uiObject.UpRelic(0);
        }

        private void SetLevelTile()
        {
            levelTitle.text = $"Level {Singleton.Instance.GetLevelData() + 1}";
        }

        public void LevelFinished()
        {
            uiTimer.StopTimer();
        }

        public void ActivateScore()
        {
            levelScore.ActivatePanel(uiTimer.GetTime());
        }
        
        public void DeactivateScore()
        {
            levelScore.DeactivatePanel();
        }

        private void ActivateIntro()
        {
            intro.alpha = 1;
            intro.interactable = true;
        }

        private void DeactivateIntro()
        {
            intro.alpha = 0;
            intro.interactable = false;
        }

        public void OnClickStartGame()
        {
            DeactivateIntro();
            Singleton.Instance.StartLevel();
        }
    }
}
