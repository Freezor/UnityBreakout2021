using Owahu.Breakout.World.PowerUps.Events;
using UnityEngine;

namespace Owahu.Breakout.World.Targets
{
    public class TargetManager : MonoBehaviour, IInvisibleBlockEvent
    {
        public int scoreOnDestroy = 100;
        public int hitsToKill = 1;
        private int _numberOfHits;

        [SerializeField] public FlashRenderer flashScript;
        [SerializeField] public TargetLootSpawner lootSpawner;
        [SerializeField] public Color flashColor;
        private Renderer _renderer;

        private void Start()
        {
            _numberOfHits = 0;
            _renderer = gameObject.GetComponent<Renderer>();
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
            if (_numberOfHits < hitsToKill)
            {
                return;
            }
            GameManager.GameManager.AddScore(scoreOnDestroy);
            Destroy(gameObject);
            lootSpawner.DropLoot();
        }

        public void OnTriggerInvisibility()
        {
            _renderer.enabled = false;
        }

        public void OnDisplayBlockAgain()
        {
            _renderer.enabled = true;
        }
    }
}