using System.Collections;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class BottomWall : PowerUp
    {
        public GameObject wall;
        public float timeBeforeSizeResetSeconds = 10;
        private GameObject _wallInstance;

        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            _wallInstance =Instantiate(wall);
            StartCoroutine(DestroyWallAfterTimeout());
        }

        private IEnumerator DestroyWallAfterTimeout()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            Destroy(_wallInstance);
        }
    }
}