using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.BD
{
    [Serializable]
    public class WallMapBd
    {
        public List<int> types;
        
        public List<float> relicsX;
        public List<float> relicsY;
        public List<float> relicsZ;
        
        public List<float> relicsRotX;
        public List<float> relicsRotY;
        public List<float> relicsRotZ;

        public WallMapBd()
        {
            types = new List<int>() { 112, 12, 12 };
            
            relicsX = new List<float>() { 112, 12, 12 };
            relicsX = new List<float>() { 112, 12, 12 };
            relicsX = new List<float>() { 112, 12, 12 };
            
            relicsRotX = new List<float>() { 112, 12, 12 };
            relicsRotY = new List<float>() { 112, 12, 12 };
            relicsRotZ = new List<float>() { 112, 12, 12 };
        }
    }
}
