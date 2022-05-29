using System;
using Game.Code.BD;
using UnityEngine;

namespace Game.Code
{
    public class RelicsMap : MonoBehaviour
    {
        public  TextAsset relicsBd;
        
        private void Start()
        {
            // var myObject = new MapBd();
            // var json = JsonUtility.ToJson(myObject);
            // Debug.Log(json);
            var myObject = JsonUtility.FromJson<MapBd>(relicsBd.text);
            Debug.Log(myObject);
        }
    }
}
