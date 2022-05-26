using UnityEngine;

namespace Game.Code
{
    public class CameraFollow : MonoBehaviour
    {
        void Update ()
        {
            gameObject.transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 12, -20);
 
        }
    }
}
