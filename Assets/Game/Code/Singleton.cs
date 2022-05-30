using System;
using Game.Code.BD;
using UnityEngine;

namespace Game.Code
{
    public class Singleton : MonoBehaviour
    {
        public static Singleton Instance { get; private set; }
        [SerializeField] private RelicsMap relicsMap;
        [SerializeField] private WallsMap wallsMap;
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

        private void ResetCurrentPieces()
        {
            CurrentPiece = 1;
        }

        private void Start()
        {
            StartLevel();
        }

        public void StartLevel()
        {
            var currentLevel = GetLevelData();
            relicMap.StartData();
            ResetCurrentPieces();
            UISingleton.Instance.StarGame();
            relicsMap.StartMap(currentLevel);
            wallsMap.StartMap(currentLevel);
            playerController.IdlePlayer();
            playerController.ActivatePlayerControl();
        }

        public void NextLevel()
        {
            SetLevelData(GetLevelData() + 1);
            StartLevel();
            UISingleton.Instance.DeactivateScore();
        }

        public void AgainLevel()
        {
            SetLevelData(GetLevelData());
            StartLevel();
            UISingleton.Instance.DeactivateScore();
        }

        public void OnTeleport()
        {
            playerController.DeactivatePlayerControl();
            UISingleton.Instance.LevelFinished();
            playerController.UpPlayer();
        }

        public void ActivateLevelScore()
        {
            UISingleton.Instance.ActivateScore();
        }

        private void SetLevelData(int currentLevel)
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }

        public int GetLevelData()
        {
            return PlayerPrefs.GetInt("CurrentLevel");
        }

        public bool IsLastLevel()
        {
            return relicsMap.GetLevels() == GetLevelData() + 1;
        }

        public void ResetAll()
        {
            SetLevelData(0);
            StartLevel();
            UISingleton.Instance.DeactivateScore();
        }
    }
}
