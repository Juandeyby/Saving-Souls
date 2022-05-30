using System;
using System.Collections;
using UnityEngine;

namespace Game.Code
{
    public class Teleport : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            EnterTeleport();
        }

        private void EnterTeleport()
        {
            Singleton.Instance.OnTeleport();
        }
    }
}
