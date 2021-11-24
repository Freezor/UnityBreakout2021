using System.Collections;
using System.Linq;
using Owahu.Breakout.World.Ball;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class DecreaseBallSize : PowerUp
    {
        
        private GameObject _ballInstance;
        public float timeBeforeSizeResetSeconds = 10;
        public float ratio = 1.0f;

        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            _ballInstance = GameObject.FindGameObjectsWithTag("Ball").First();
            _ballInstance.GetComponent<BallTransformation>().DecreaseSize(ratio);
            StartCoroutine(IncreaseBallSizeAfterTimeOut());
        }

        private IEnumerator IncreaseBallSizeAfterTimeOut()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            if (_ballInstance != null)
            {
                _ballInstance.GetComponent<BallTransformation>().IncreaseSize(ratio);
            }
        }
    }
}