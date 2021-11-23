using UnityEngine;

namespace Owahu.Breakout.Player
{
    public class PlayerBrain : MonoBehaviour
    {
        public Animator animator;

        public static PlayerBrain Instance;
        private const string PickedSizeIncrease = "Picked_Size_Increase";
        private const string PickedSizeDecrease = "Picked_Size_Decrease";
        private const string AnimationFinished = "Animation_Finished";

        void Start()
        {
            if (Instance != null) return;
            Instance = this;
        }

        public void IncreaseSize()
        {
            animator.SetTrigger(PickedSizeIncrease);
        }

        public void DecreaseSize()
        {
            animator.SetTrigger(PickedSizeDecrease);
        }

        public void FinishAnimation()
        {
            animator.SetTrigger(AnimationFinished);
        }
    }
}