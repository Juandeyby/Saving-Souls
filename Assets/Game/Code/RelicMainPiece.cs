using System;
using UnityEngine;

namespace Game.Code
{
    public class RelicMainPiece : MonoBehaviour
    {
        [SerializeField] private Material pieceEnabled;
        [SerializeField] private Material pieceDisabled;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void EnabledPiece()
        {
            _renderer.material = pieceEnabled;
        }
        
        public void DisabledPiece()
        {
            _renderer.material = pieceDisabled;
        }
    }
}
