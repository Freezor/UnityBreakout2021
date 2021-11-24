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

            if (_ballRigidBody.position.y < -2)
            {
                ResetBall();
            }
        }

        private void ResetBall()
        {
            GameManager.GameManager.Instance.AddScoreToHighScore();
            if (GameManager.GameManager.Instance.OnlyOneBallInGame())
            {
                GameManager.GameManager.Instance.RemoveLife();
                _isLaunched = false;
                SetBallPositionAbovePlayerPosition();
            }
            else
            {
                GameManager.GameManager.Instance.BallsInGame--;
                Destroy(this);
            }
        }

        private void FixedUpdate()
        {
            if (!_isLaunched)
            {
                SetBallPositionAbovePlayerPosition();
            }
        }

        private void SetBallPositionAbovePlayerPosition()
        {
            var position = _player.position;
            _ballRigidBody.position =
                new Vector2(position.x, position.y + PositionYModificatorToDisplayBallAbovePlayer);
        }

        void OnCollisionEnter2D(Collision2D collision2D)
        {
            switch (collision2D.gameObject.name.ToLower())
            {
                // Hit the Racket?
                case "player":
                {
                    GameManager.GameManager.Instance.AddScoreToHighScore();
                    CalculateRacketCollision(collision2D);
                    break;
                }
                case "block":
                    GameManager.GameManager.Instance.AddScoreMultiplier();
                    break;
            }
        }

        private void CalculateRacketCollision(Collision2D collision2D)
        {
            var xAxisDirection = HitFactor(transform.position,
                collision2D.transform.position,
                collision2D.collider.bounds.size.x);

            // Calculate direction, set length to 1
            var direction = new Vector2(xAxisDirection, 1).normalized;

            // Set Velocity with dir * speed
            _ballRigidBody.velocity = direction * speed;

            var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            _ballRigidBody.velocity += tweak;
        }

        private float HitFactor(Vector2 ballPosition, Vector2 racketPosition,
            float racketWidth)
        {
            // ascii art:
            //
            // 1  -0.5  0  0.5   1  <- x value
            // ===================  <- racket
            //
            return (ballPosition.x - racketPosition.x) / racketWidth;
        }
    }
}