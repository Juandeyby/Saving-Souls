using UnityEngine;

namespace Game.Code
{
    public class RelicPiece : MonoBehaviour
    {
        [SerializeField] private int pieceIndex;
        [SerializeField] private AudioClip pickUp;
        
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
            UISingleton.Instance.UpRelic(pieceIndex);
            Sound();
            Destroy(gameObject);
        }

        private void Sound()
        {
            Singleton.Instance.PlaySound(pickUp);
        }
    }
}