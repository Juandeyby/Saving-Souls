using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code
{
    public class RelicMain : MonoBehaviour
    {
        public static RelicMain Instance { get; private set; }
        [SerializeField] private List<RelicMainPiece> mainPieces;
        [SerializeField] private GameObject teleport;
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

        public void StartData()
        {
            var relicsTotal = mainPieces.Count;
            _relics = new bool[relicsTotal];
            DeactivateTeleport();
        }

        public void AddPiece(int pieceIndex)
        {
            if (_relics[pieceIndex - 1]) return;
            _relics[pieceIndex - 1] = true;
            mainPieces[pieceIndex - 1].EnabledPiece();
        }

        public void ActivateTeleport()
        {
            teleport.gameObject.SetActive(true);
        }

        public void DeactivateTeleport()
        {
            teleport.gameObject.SetActive(false);
        }
    }
}
