using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Owahu.Breakout.World.Ball
{
    public class BallMovement : MonoBehaviour
    {
        public float speed = 2.0f;
        public float moveForce = 0.002f;

        private Rigidbody2D _ballRigidBody;
        private bool _isLaunched = false;
        private Rigidbody2D _player;
        const float PositionYModificatorToDisplayBallAbovePlayer = 0.05f;

        // Use this for initialization
        void Start()
        {
            _ballRigidBody = GetComponent<Rigidbody2D>();
            _player = GameObject.FindGameObjectsWithTag("Player").First().GetComponent<Rigidbody2D>();
        }

        public void LaunchBall()
        {
            _isLaunched = true;

            _ballRigidBody.velocity = Vector2.up * speed;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _ballRigidBody.AddForce(new Vector2(moveForce * -1, 0), ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                _ballRigidBody.AddForce(new Vector2(moveForce, 0), ForceMode2D.Impulse);
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                LaunchBall();
            }
        }

        private void FixedUpdate()
        {
            if (!_isLaunched)
            {
                var position = _player.position;
                _ballRigidBody.position =
                    new Vector2(position.x, position.y + PositionYModificatorToDisplayBallAbovePlayer);
            }

            if (_ballRigidBody.position.y < -2)
            {
                _ballRigidBody.position = Vector2.zero;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            // Hit the Racket?
            if (col.gameObject.name.ToLower() != "player")
            {
                return;
            }

            // Calculate hit Factor
            var x = HitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            var dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            _ballRigidBody.velocity = dir * speed;

            var tweak = new Vector2(Random.Range(0f, 0.1f), Random.Range(0f, 0.1f));
            _ballRigidBody.velocity += tweak;
        }

        private float HitFactor(Vector2 ballPos, Vector2 racketPos,
            float racketWidth)
        {
            // ascii art:
            //
            // 1  -0.5  0  0.5   1  <- x value
            // ===================  <- racket
            //
            return (ballPos.x - racketPos.x) / racketWidth;
        }
    }
}