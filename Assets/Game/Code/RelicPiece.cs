using UnityEngine;

namespace Game.Code
{
    public class RelicPiece : MonoBehaviour
    {
        [SerializeField] private int pieceIndex;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PickUpRelic();
            }
        }

        private void PickUpRelic()
        {
            RelicMain.Instance.AddPiece(pieceIndex);
            Destroy(gameObject);
        }
    }
}
