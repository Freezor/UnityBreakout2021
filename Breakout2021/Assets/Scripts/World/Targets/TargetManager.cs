using System;
using System.Collections.Generic;
using Owahu.Breakout.World.PowerUps;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Owahu.Breakout.World.Targets
{
    public class TargetManager : MonoBehaviour
    {
        public int scoreOnDestroy = 100;
        public int hitsToKill = 1;
        private int _numberOfHits;

        [SerializeField] public FlashRenderer flashScript;
        [SerializeField] public TargetLootSpawner lootSpawner;
        [SerializeField] public Color flashColor;
        
        private void Start()
        {
            _numberOfHits = 0;
            lootSpawner.DropLoot();
        }


        void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (!collisionInfo.gameObject.tag.Equals("Ball"))
            {
                return;
            }

            if (flashScript != null)
            {
                flashScript.Flash(flashColor);
            }
            
            _numberOfHits++;
            if (_numberOfHits >= hitsToKill)
            {
                Destroy(gameObject);
            }
        }
    }
}