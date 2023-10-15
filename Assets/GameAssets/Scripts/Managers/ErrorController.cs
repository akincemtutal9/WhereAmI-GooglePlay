using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.Managers
{
    public class ErrorController : MonoBehaviour
    {
        [SerializeField] private AudioClip errorClip;
        [SerializeField] private GameObject errorObject;
        [SerializeField] private TextMeshProUGUI errorText;
        [SerializeField] private Slider slider;
        [SerializeField] private float displayDuration = 3.0f;

        private bool isErrorActive = false;

        private static ErrorController instance;

        public static ErrorController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ErrorController>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void OnEnable()
        {
            slider.value = 1;
        }

        public void ShowError(string errorMessage)
        {
            if (!isErrorActive)
            {
                errorObject.SetActive(true); // Error objesini etkinleştirin
                SoundManager.instance.PlaySoundEffect(errorClip);
                errorText.text = errorMessage; // Hata mesajını ayarlayın
                isErrorActive = true;

                StartCoroutine(HideErrorAfterDelay());
            }
        }

        private IEnumerator HideErrorAfterDelay()
        {
            float startTime = Time.time;
            float elapsedTime = 0.0f;

            while (elapsedTime < displayDuration)
            {
                elapsedTime = Time.time - startTime;
                float normalizedTime = elapsedTime / displayDuration;
                slider.value = 1 - normalizedTime;

                yield return null;
            }

            errorObject.SetActive(false); // Hata mesajını gizle
            isErrorActive = false;
        }
    }
}
