using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;

namespace GameAssets.Scripts.Managers
{
    public class AdmobAdsManager : MonoBehaviour
    {
        private static AdmobAdsManager instance;
        public static AdmobAdsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<AdmobAdsManager>();
                }
                return instance;
            }
        }

        [SerializeField] private TextMeshProUGUI totalCoinsText;
        [SerializeField] private string appID = "ca-app-pub-3940256099942544~3347511713";
        
        #if UNITY_ANDROID
        private string bannerID = "ca-app-pub-3940256099942544/6300978111";
        private string interID = "ca-app-pub-3940256099942544/1033173712";
        private string rewardedID = "ca-app-pub-3940256099942544/5224354917";
        private string nativeID = "ca-app-pub-3940256099942544/2247696110";
        #elif UNITY_IPHONE
        private string bannerID = "ca-app-pub-3940256099942544/2934735716";
        private string interID = "ca-app-pub-3940256099942544/4411468910";
        private string rewardedID = "ca-app-pub-3940256099942544/1712485313";
        private string nativeID = "ca-app-pub-3940256099942544/3986624511";
        #endif

        private BannerView bannerView;
        private InterstitialAd interstitialAd;
        private RewardedAd rewardedAd;
        private NativeAd nativeAd;
        
        
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            } else {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
     
        
        
        
        
    }
}
