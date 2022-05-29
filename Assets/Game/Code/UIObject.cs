using UnityEngine;
using UnityEngine.UI;

namespace Game.Code
{
    public class UIObject : MonoBehaviour
    {
        [SerializeField] private Sprite [] parts;
        [SerializeField] private Image main;

        public void UpRelic(int order)
        {
            main.sprite = parts[order + 1];
        }
    }
}
