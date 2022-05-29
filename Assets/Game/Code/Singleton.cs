using System;
using UnityEngine;

namespace Game.Code
{
    public class Singleton : MonoBehaviour
    {
        public static Singleton Instance { get; private set; }
        private AudioSource _audioSource;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this);
                return;
            } 
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip audioClip)
        {
            AudioSource.PlayClipAtPoint(audioClip, Vector3.zero, 0.5f);
        }

        private void Start()
        {
            UISingleton.Instance.StarGame();
        }
    }
}
