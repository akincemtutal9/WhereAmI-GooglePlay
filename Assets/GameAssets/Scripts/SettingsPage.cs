using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class SettingsPage : GameStateManagerProvider
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button sfxButton;
        [SerializeField] private TMP_Text sfxText;
        [SerializeField] private Button soundButton;
        [SerializeField] private TMP_Text soundText;
        
        private bool isSfxOpen;
        private bool isSoundOpen;
        
        
        protected override void Start()
        {
            isSfxOpen = true;
            isSoundOpen = true;
            OnSfxButtonClicked();
            OnSoundButtonClicked();

            base.Start();
            backButton.onClick.AddListener(OnBackButtonClicked);
            sfxButton.onClick.AddListener(OnSfxButtonClicked);
            soundButton.onClick.AddListener(OnSoundButtonClicked);
        }

        private void OnSoundButtonClicked()
        {
            if (isSoundOpen)
            {
                soundButton.image.color = Color.blue;
                soundText.text = "Sound: ON";
                isSoundOpen = false;
            }
            else
            {
                soundButton.image.color = Color.red;
                soundText.text = "Sound: OFF";
                isSoundOpen = true;   
            }
        }
        private void OnSfxButtonClicked()
        {
            if (isSfxOpen)
            {
                sfxButton.image.color = Color.blue;
                sfxText.text = "SFX: ON";
                isSfxOpen = false;
            }
            else
            {
                sfxButton.image.color = Color.red;
                sfxText.text = "SFX: OFF";
                isSfxOpen = true;   
            }
        }
        private void OnBackButtonClicked()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.MAINMENU);
        }
    }
}
