using System;
using UnityEngine;

namespace Owahu.Breakout.World.Ball
{
    public class BallTransformation : MonoBehaviour
    {
        public void IncreaseSize(float ratio)
        {
            var transformLocalScale = transform.localScale;
            var scaleChange = new Vector3(transformLocalScale.x + ratio, transformLocalScale.y + ratio,
                transformLocalScale.z);
            transform.localScale = scaleChange;
        }

        public void DecreaseSize(float ratio)
        {
            // TODO: Gameoverscreen, transition to next level, Start Selection Menu, GameManager check if balls = 0 and spawn new ball if life >0
            var transformLocalScale = transform.localScale;
            var scaleChange = new Vector3(transformLocalScale.x - ratio, transformLocalScale.y - ratio,
                transformLocalScale.z);
            
            transform.localScale = scaleChange;
        }
    }
}