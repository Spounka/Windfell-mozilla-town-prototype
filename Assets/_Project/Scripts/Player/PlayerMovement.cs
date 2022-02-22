using UnityEngine;

namespace Spounka.Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _rb;


        public PlayerMovement(Rigidbody2D rb)
        {
            _rb = rb;
        }

        public void Move(Vector2 input, float movementSpeed, float deltaTime)
        {
            var dir = input.normalized;
            var velocity = dir * movementSpeed;

            _rb.MovePosition(_rb.position + (velocity * deltaTime));
        }
    }
}