using System;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private int _damageToDeal = 3;
        [SerializeField] private float _damageRadius = 1;

        private Collider2D _currentCollider;

        private void Awake()
        {
            _currentCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var results = new Collider2D[20];
                var size = Physics2D.OverlapCircleNonAlloc(transform.position, _damageRadius, results);
                for (var i = 0; i < size; i++)
                {
                    if (results[i] == _currentCollider)
                        continue;

                    var health = results[i].GetComponent<HealthSystem>();
                    if (health != null)
                        health.TakeDamage(_damageToDeal);
                }
            }
        }
    }
}