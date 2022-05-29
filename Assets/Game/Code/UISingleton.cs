using UnityEngine;

namespace Game.Code
{
    public class UISingleton : MonoBehaviour
    {
        public static UISingleton Instance { get; private set; }
        [SerializeField] private UIObject uiObject;
        [SerializeField] private UITimer uiTimer;
        
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
            uiTimer.StartTimer();
        }
    }
}
