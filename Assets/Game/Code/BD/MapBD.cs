using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.BD
{
    [Serializable]
    public class MapBd
    {
        public List<float> relicsX;
        public List<float> relicsY;
        public List<float> relicsZ;

        public MapBd()
        {
            relicsX = new List<float>() { 112, 12, 12 };
        }
    }
}
