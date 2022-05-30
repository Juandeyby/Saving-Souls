using UnityEngine;
using UnityEngine.UI;

namespace Game.Code
{
    public class UIObject : MonoBehaviour
    {
        [SerializeField] private Sprite [] parts;
        [SerializeField] private Image main;
        [SerializeField] private Image next;

        public void UpRelic(int order)
        {
            main.sprite = parts[order];
            var nextPart = order + 1;
            if (parts.Length > nextPart)
            {
                next.sprite = parts[nextPart];
            }
        }
    }
}
