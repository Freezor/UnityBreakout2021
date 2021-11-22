using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Owahu.Breakout.World.PowerUps
{
    public class PowerUp : MonoBehaviour
    {
        [Range(0.0f,1.0f)]
        public float weight = 1.0f;
        
        private Rigidbody2D _powerUpRigidBody;

        private void Start()
        {
            _powerUpRigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (!collisionInfo.gameObject.tag.Equals("Player"))
            {
                return;
            }
            
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            if (_powerUpRigidBody.position.y < -2)
            {
                Destroy(gameObject);
            }
        }
    }
}
