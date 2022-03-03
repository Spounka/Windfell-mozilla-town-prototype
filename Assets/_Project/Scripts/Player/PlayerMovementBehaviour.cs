using System;
using UnityEngine;

namespace Spounka.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0;

        private Vector2 _input = Vector2.zero;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var direction = _input.normalized;
            var velocity = direction * _movementSpeed;

            _rb.MovePosition(_rb.position + (velocity * Time.fixedDeltaTime));
        }
    }
}