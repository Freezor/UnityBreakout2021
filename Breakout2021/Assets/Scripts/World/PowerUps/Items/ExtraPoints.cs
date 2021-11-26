using System.Collections;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class ExtraPoints : PowerUp
    {
        public int scoreMultiplier = 5;
        public float timeBeforeSizeResetSeconds = 10;
        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            GameManager.GameManager.Instance.temporaryScoreMultiplier += scoreMultiplier;
            StartCoroutine(RemoveMultiplier());
        }

        private IEnumerator RemoveMultiplier()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            GameManager.GameManager.Instance.temporaryScoreMultiplier -= scoreMultiplier;
        }
    }
}