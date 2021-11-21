using System;
using UnityEngine;

namespace Owahu.Breakout.Player
{
    public class RacketMovement : MonoBehaviour
    {
        public float speed = 5.0f;
        private Rigidbody2D _racketObject;

        private void Start()
        {
            _racketObject = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var h = Input.GetAxisRaw("Horizontal");

            // Set Velocity (movement direction * speed)
            _racketObject.velocity = Vector2.right * h * speed;
        }
    }
}
