using System.Collections;
using System.Collections.Generic;
using Owahu.Breakout.World.PowerUps.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Owahu.Breakout.World.PowerUps.Items
{
    public class InvisibleBlocks : PowerUp
    {
        public int invisibilitySeconds = 3;
        protected override void PowerUpPayload()
        {
            base.PowerUpPayload();
            foreach (var go in EventSystemListeners.main.listeners)
            {
                ExecuteEvents.Execute<IInvisibleBlockEvent>(go, null, (x, y) => x.OnTriggerInvisibility());
            }

            StartCoroutine(DisplayBoxAfterTimeCoroutine());
        }

        IEnumerator DisplayBoxAfterTimeCoroutine()
        {
            yield return new WaitForSeconds(invisibilitySeconds);

            foreach (var go in EventSystemListeners.main.listeners)
            {
                ExecuteEvents.Execute<IInvisibleBlockEvent>(go, null, (x, y) => x.OnDisplayBlockAgain());
            }
        }
    }
}