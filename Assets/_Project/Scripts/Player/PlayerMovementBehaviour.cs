using System;
using UnityEngine;

namespace Spounka.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0;

        private PlayerMovement _playerMovement;
        private IInput _input;

        private void Awake()
        {
            _playerMovement = new PlayerMovement(GetComponent<Rigidbody2D>());
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_input.GetAxis, _movementSpeed, Time.fixedDeltaTime);
        }
    }

    public interface IInput
    {
        public Vector2 GetAxis { get; }
    }
}