using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Owahu.Breakout.Player
{
    public class PlayerBrain : MonoBehaviour
    {
        public Animator animator;
        public int timeBeforeSizeResetSeconds = 10;
        public static PlayerBrain Instance;
        private const string PickedSizeIncrease = "Picked_Size_Increase";
        private const string PickedSizeDecrease = "Picked_Size_Decrease";
        private const string AnimationFinished = "Animation_Finished";
        private const string PowerTimeOut = "Power_TimeOut";


        void Start()
        {
            if (Instance != null) return;
            Instance = this;
        }

        public void IncreaseSize()
        {
            animator.SetTrigger(PickedSizeIncrease);
            StartCoroutine(ResetSize());
        }

        public void DecreaseSize()
        {
            animator.SetTrigger(PickedSizeDecrease);
            StartCoroutine(ResetSize());
        }

        public void FinishAnimation()
        {
            animator.SetTrigger(AnimationFinished);
        }

        private IEnumerator ResetSize()
        {
            yield return new WaitForSeconds(timeBeforeSizeResetSeconds);
            animator.SetTrigger(PowerTimeOut);
        }
    }
}