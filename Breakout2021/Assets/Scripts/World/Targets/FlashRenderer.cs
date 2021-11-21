using System.Collections;
using UnityEngine;

namespace Owahu.Breakout.World.Targets
{
    public class FlashRenderer : MonoBehaviour
    {
        #region Datamembers

        #region Editor Settings

        [Tooltip("Material to switch to during the flash.")] [SerializeField]
        private Material flashMaterial;

        [Tooltip("Duration of the flash.")] [SerializeField]
        private float duration;

        #endregion

        #region Private Fields

        // The SpriteRenderer that should flash.
        private SpriteRenderer _spriteRenderer;

        // The material that was in use, when the script started.
        private Material _originalMaterial;

        // The currently running coroutine.
        private Coroutine _flashRoutine;

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        void Start()
        {
            // Get the SpriteRenderer to be used,
            // alternatively you could set it from the inspector.
            _spriteRenderer = GetComponent<SpriteRenderer>();

            // Get the material that the SpriteRenderer uses, 
            // so we can switch back to it after the flash ended.
            _originalMaterial = _spriteRenderer.material;

            // Copy the flashMaterial material, this is needed, 
            // so it can be modified without any side effects.
            flashMaterial = new Material(flashMaterial);
        }

        #endregion

        public void Flash(Color color)
        {
            // If the flashRoutine is not null, then it is currently running.
            if (_flashRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(_flashRoutine);
            }

            // Start the Coroutine, and store the reference for it.
            _flashRoutine = StartCoroutine(FlashRoutine(color));
        }

        private IEnumerator FlashRoutine(Color color)
        {
            // Swap to the flashMaterial.
            _spriteRenderer.material = flashMaterial;

            // Set the desired color for the flash.
            flashMaterial.color = color;

            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(duration);

            // After the pause, swap back to the original material.
            _spriteRenderer.material = _originalMaterial;

            // Set the flashRoutine to null, signaling that it's finished.
            _flashRoutine = null;
        }

        #endregion
    }
}