using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class ExtraBall : PowerUp
    {
        public GameObject ballPrefab;
        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            GameManager.GameManager.Instance.BallsInGame++;
            Instantiate(ballPrefab);
        }
    }
}