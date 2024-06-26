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
                soundButton.image.color = HexToColor("F2C84B"); // Sarı
                soundText.text = "Sound: ON";
                isSoundOpen = false;
                SoundManager.instance.StartMusic();
            }
            else
            {
                soundButton.image.color = HexToColor("F26457");// Kırmızı
                soundText.text = "Sound: OFF";
                isSoundOpen = true;   
                SoundManager.instance.StopMusic();
            }
        }
        private void OnSfxButtonClicked()
        {
            if (isSfxOpen)
            {
                sfxButton.image.color = HexToColor("F2C84B"); // Blue
                sfxText.text = "SFX: ON";
                isSfxOpen = false;
                SoundManager.instance.StartSfx();
            }
            else
            {
                sfxButton.image.color = HexToColor("F26457"); // Red
                sfxText.text = "SFX: OFF";
                isSfxOpen = true;   
                SoundManager.instance.StopSfx();
            }
        }
        private Color HexToColor(string hex)
        {
            if (ColorUtility.TryParseHtmlString("#" + hex, out Color color))
            {
                return color;
            }
            // Return a default color if parsing fails
            return Color.white;
        }
        private void OnBackButtonClicked()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.MAINMENU);
        }
    }
}
