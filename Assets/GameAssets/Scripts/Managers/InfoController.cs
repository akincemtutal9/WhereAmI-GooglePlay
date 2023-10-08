using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.Managers
{
    public class InfoController : MonoBehaviour
    {
        [SerializeField] private GameObject infoObject;
        [SerializeField] private TextMeshProUGUI infoText;
        [SerializeField] private Slider slider;
        [SerializeField] private float displayDuration = 3.0f;

        private bool isInfoActive = false;

        private static InfoController instance;

        public static InfoController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InfoController>();
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

        public void ShowInfo(string info)
        {
            if (!isInfoActive)
            {
                infoObject.SetActive(true);
                infoText.text = info; 
                isInfoActive = true;

                StartCoroutine(HideInfoAfterDelay());
            }
        }

        private IEnumerator HideInfoAfterDelay()
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

            infoObject.SetActive(false);
            isInfoActive = false;
        }  
    }
}
