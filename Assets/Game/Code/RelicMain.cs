using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code
{
    public class RelicMain : MonoBehaviour
    {
        public static RelicMain Instance { get; private set; }
        [SerializeField] private List<RelicMainPiece> mainPieces;
        private bool [] _relics;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            var relicsTotal = transform.childCount;
            _relics = new bool[relicsTotal];
        }

        public void AddPiece(int pieceIndex)
        {
            if (_relics[pieceIndex]) return;
            _relics[pieceIndex] = true;
            mainPieces[pieceIndex].EnabledPiece();
        }
    }
}
