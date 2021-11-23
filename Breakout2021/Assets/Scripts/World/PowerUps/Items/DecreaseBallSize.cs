using System.Collections;
using System.Linq;
using Owahu.Breakout.World.Ball;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class DecreaseBallSize : PowerUp
    {
        
        private GameObject ballInstance;
        public float timeBeforeSizeResetSeconds = 10;
        public float ratio = 1.0f;

        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            ballInstance = GameObject.FindGameObjectsWithTag("Ball").First();
            ballInstance.GetComponent<BallTransformation>().DecreaseSize(ratio);
            StartCoroutine(IncreaseBallSizeAfterTimeOut());
        }

        private IEnumerator IncreaseBallSizeAfterTimeOut()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            if (ballInstance != null)
            {
                ballInstance.GetComponent<BallTransformation>().IncreaseSize(ratio);
            }
        }
    }
}