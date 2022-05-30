using System;
using UnityEngine;

namespace Game.Code
{
    public class CharacterEvent : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Up = Animator.StringToHash("Up");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void TeleportCompleted()
        {
            Singleton.Instance.ActivateLevelScore();
        }

        public void ActivateUpAnimation()
        {
            _animator.SetBool(Up, true);
        }
        
        public void DeactivateUpAnimation()
        {
            _animator.SetBool(Up, false);
        }
    }
}
