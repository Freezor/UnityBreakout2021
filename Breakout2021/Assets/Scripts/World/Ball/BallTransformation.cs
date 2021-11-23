using System;
using UnityEngine;

namespace Owahu.Breakout.World.Ball
{
    public class BallTransformation : MonoBehaviour
    {
        private void Start()
        {
        }

        public void IncreaseSize(float ratio)
        {
            var transformLocalScale = transform.localScale;
            var scaleChange = new Vector3(transformLocalScale.x + ratio, transformLocalScale.y + ratio,
                transformLocalScale.z);
            transform.localScale = scaleChange;
        }

        public void DecreaseSize(float ratio)
        {
            
            var transformLocalScale = transform.localScale;
            var scaleChange = new Vector3(transformLocalScale.x - ratio, transformLocalScale.y - ratio,
                transformLocalScale.z);

            //if (transformLocalScale.x < 0.1f)
            //{
            //    transformLocalScale.x = 0.1f;
            //    transformLocalScale.y = 0.1f;
            //}
            
            transform.localScale = scaleChange;
        }
    }
}