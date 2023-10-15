using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class IndexPage : GameStateManagerProvider
    {
        [Header("Top Panel")] 
        [SerializeField] private Button freeGoldButton;
        [SerializeField] private Button settingsButton;
        
        [Header("Main Panel")]
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button playerLibraryButton;
        [SerializeField] private Button linkedinButton;
        [SerializeField] private Button instagramButton;
        [SerializeField] private Button googlePlayButton;
        
        protected override void Start()
        {
            base.Start();
            freeGoldButton.onClick.AddListener(HandleFreeGoldButtonClicked);
            settingsButton.onClick.AddListener(HandleSettingsButtonClicked);
            startGameButton.onClick.AddListener(HandleStartGameButtonClicked);
            playerLibraryButton.onClick.AddListener(HandlePlayerLibraryButtonClicked);
            linkedinButton.onClick.AddListener(HandleLinkedinButtonClicked);
            instagramButton.onClick.AddListener(HandleInstagramButtonClicked);
            googlePlayButton.onClick.AddListener(HandleGooglePlayButtonClicked);
        }
        private void HandleFreeGoldButtonClicked()
        {
            AdmobAdsManager.Instance.ShowRewardedAd();
        }
        private void HandleSettingsButtonClicked()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.SETTINGS);
        }
        private void HandleStartGameButtonClicked()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.STARTGAME);
        }
        private void HandlePlayerLibraryButtonClicked()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.PLAYERLIBRARY);
        }
        private void HandleLinkedinButtonClicked()
        {
            UrlOpener.OpenUrl("https://www.linkedin.com/in/ak%C4%B1n-cem-tutal-6ba1a7209/");
        }
        private void HandleInstagramButtonClicked()
        {
            UrlOpener.OpenUrl("https://www.instagram.com/akincemtutal/");
        }
        private void HandleGooglePlayButtonClicked()
        {
            UrlOpener.OpenUrl("https://play.google.com/store/apps/developer?id=akincemtutal&hl=en_US");
        }
    }
}
