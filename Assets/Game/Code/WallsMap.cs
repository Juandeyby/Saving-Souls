using Game.Code.BD;
using UnityEngine;

namespace Game.Code
{
    public class WallsMap : MonoBehaviour
    {
        [SerializeField] private TextAsset[] wallsBds;
        [SerializeField] private Transform relicsParent;
        [SerializeField] private Transform[] wallPieces;

        private void ResetMap()
        {
            foreach (Transform relic in relicsParent)
            {
                Destroy(relic.gameObject);
            }
        }
        
        public void StartMap(int currentLevel)
        {
            ResetMap();
            CreateWallOnMap(currentLevel);
        }
        
        private WallMapBd GetData(int level)
        {
            var data = JsonUtility.FromJson<WallMapBd>(wallsBds[level].text);
            return data;
        }
        
        private void CreateWallOnMap(int level)
        {
            var data = GetData(level);
            for (var i = 0; i < data.types.Count; i++)
            {
                var position = new Vector3(data.relicsX[i], data.relicsY[i], data.relicsZ[i]);
                var rotation = Quaternion.Euler(data.relicsRotX[i], data.relicsRotY[i], data.relicsRotZ[i]);
                var relic = Instantiate(wallPieces[data.types[i]], position, rotation, relicsParent);
            }
        }
    }
}
