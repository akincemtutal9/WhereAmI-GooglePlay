using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public class ScaleUI : MonoBehaviour
    {
        // The UI gameobject to scale
        public GameObject uiObject;

        // The duration of the scaling animation in seconds
        public float duration = 1f;

        // The scale factor to multiply the original size
        public float scaleFactor = 1.5f;

        // The easing function to use for the animation
        public Ease easeType = Ease.InOutSine;

        // The original size of the UI gameobject
        private Vector3 originalSize;

        // Start is called before the first frame update
        void Start()
        {
            // Store the original size of the UI gameobject
            originalSize = uiObject.transform.localScale;

            // Start the scaling animation once
            Scale();
        }

        // The method that performs the scaling animation using DoTween
        void Scale()
        {
            // Calculate the target size by multiplying the original size with the scale factor
            Vector3 targetSize = originalSize * scaleFactor;

            // Use DoTween to scale the UI gameobject from its current size to the target size and back to the original size
            // The total duration of the animation is twice the duration variable
            // The easing function is specified by the easeType variable
            // The loop parameter is set to -1 to make the animation repeat indefinitely
            uiObject.transform.DOScale(targetSize, duration).SetEase(easeType).SetLoops(-1, LoopType.Yoyo);
        }
    }
}