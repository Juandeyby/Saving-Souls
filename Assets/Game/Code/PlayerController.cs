using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Code
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float rotationSpeed = 180;
        [SerializeField] private CharacterEvent characterEvent;
        private CharacterController _controller;
        private Vector2 _direction;
        private Vector3 _rotation;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            _rotation = new Vector3(0, _direction.x * rotationSpeed * Time.deltaTime, 0);
            var move = new Vector3(0, 0, _direction.y * Time.deltaTime);
            if (_direction.y < 0f)
                move = Vector3.zero;
            move = transform.TransformDirection(move);
            move.y -= 2f * Time.deltaTime;
            _controller.Move(move * speed);
            transform.Rotate(_rotation);
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        public void UpPlayer()
        {
            characterEvent.ActivateUpAnimation();
        }
    }
}