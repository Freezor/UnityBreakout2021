using System.Collections;
using System.Linq;
using Owahu.Breakout.World.Ball;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class IncreaseBallSize : PowerUp
    {
        private GameObject ballInstance;
        public float timeBeforeSizeResetSeconds = 10;
        public float ratio = 1.0f;

        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            ballInstance = GameObject.FindGameObjectsWithTag("Ball").First();
            ballInstance.GetComponent<BallTransformation>().IncreaseSize(ratio);
            StartCoroutine(DecreaseBallSizeAfterTimeOut());
        }

        private IEnumerator DecreaseBallSizeAfterTimeOut()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            if (ballInstance != null)
            {
                ballInstance.GetComponent<BallTransformation>().DecreaseSize(ratio);
            }
        }
    }
}