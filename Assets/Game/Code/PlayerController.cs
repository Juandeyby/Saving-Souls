using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Code
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;
        private Vector2 _direction;
        
        public void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            transform.Translate( new Vector3(_direction.x, 0, _direction.y) * (speed * Time.deltaTime));
        }

        private void Update()
        {
            MovePlayer();
        }
    }
}
