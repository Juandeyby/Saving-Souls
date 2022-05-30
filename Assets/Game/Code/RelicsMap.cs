using System;
using Game.Code.BD;
using UnityEngine;

namespace Game.Code
{
    public class RelicsMap : MonoBehaviour
    {
        [SerializeField] private TextAsset[] relicsBds;
        [SerializeField] private Transform relicsParent;
        [SerializeField] private RelicPiece[] relicPieces;

        public void ResetMap()
        {
            foreach (Transform relic in relicsParent)
            {
                Destroy(relic.gameObject);
            }
        }

        public void StartMap(int currentLevel)
        {
            CreateRelicOnMap(currentLevel);
        }

        private MapBd GetData(int level)
        {
            var data = JsonUtility.FromJson<MapBd>(relicsBds[level].text);
            return data;
        }

        private void CreateRelicOnMap(int level)
        {
            var data = GetData(level);
            for (var i = 0; i < data.relicsX.Count; i++)
            {
                var position = new Vector3(data.relicsX[i], data.relicsY[i], data.relicsZ[i]);
                var rotation = new Quaternion(0, 0, 0, 0);
                var relic = Instantiate(relicPieces[i], position, rotation, relicsParent);
            }
        }

        public bool IsCompletePieces(int current)
        {
            return current - 1 == relicPieces.Length;
        }

        public int GetLevels()
        {
            return relicsBds.Length;
        }
    }
}
