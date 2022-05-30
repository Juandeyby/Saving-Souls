using System;
using UnityEngine;

namespace Game.Code
{
    public class Singleton : MonoBehaviour
    {
        public static Singleton Instance { get; private set; }
        [SerializeField] private RelicsMap relicsMap;
        [SerializeField] private RelicMain relicMap;
        [SerializeField] private PlayerController playerController;
        private AudioSource _audioSource;
        public int CurrentPiece { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this);
                return;
            } 
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            CurrentPiece = 1;
        }

        public void PlaySound(AudioClip audioClip)
        {
            AudioSource.PlayClipAtPoint(audioClip, Vector3.zero, 0.5f);
        }

        public void PickUpPiece()
        {
            CurrentPiece++;
            if (relicsMap.IsCompletePieces(CurrentPiece))
            {
                relicMap.ActivateTeleport();
            }
        }

        public void ResetCurrentPieces()
        {
            CurrentPiece = 1;
        }

        private void Start()
        {
            relicMap.StartData();
            UISingleton.Instance.StarGame();
            relicsMap.StartMap();
        }

        public void OnTeleport()
        {
            UISingleton.Instance.LevelFinished();
            playerController.UpPlayer();
        }
    }
}
