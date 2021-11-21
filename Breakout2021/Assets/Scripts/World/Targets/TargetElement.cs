using UnityEngine;

namespace Owahu.Breakout.World.Targets
{
    public class TargetElement : MonoBehaviour
    {
        public int scoreOnDestroy = 100;
        public int hitsToKill = 1;
        private int _numberOfHits;

        [SerializeField] public FlashRenderer flashScript;
        [SerializeField] public Color flashColor = Color.white;
        
        private void Start()
        {
            _numberOfHits = 0;
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