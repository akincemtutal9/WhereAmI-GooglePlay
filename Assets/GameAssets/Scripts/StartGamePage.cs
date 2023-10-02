using GameAssets.Scripts.Utils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class StartGamePage : GameStateManagerProvider
    {
        [SerializeField] private GameObject topPanel;
        [SerializeField] private Button backToMainPageButton;
        [SerializeField] private Button addPlayerButton;

        [SerializeField] private GameObject mainPanel;
        [SerializeField] private Button startGameButton;

        
        [SerializeField] private GameObject playerAddingPanel;
        [SerializeField] private Button closePlayerAddingPanelButton;
        [SerializeField] private Button addPlayerToGameButton;
        protected override void Start()
        {
            HandleClosePlayerAddingPanelButton();// Unutursak hieraarchy'de kodla kapatsın gereksiz uiları
            
            base.Start();
            backToMainPageButton.onClick.AddListener(HandleBackToMainPageButton);
            addPlayerButton.onClick.AddListener(HandleAddPlayerButton);
            //startGameButton.onClick.AddListener(HandleStartGameButton);
            closePlayerAddingPanelButton.onClick.AddListener(HandleClosePlayerAddingPanelButton);
            addPlayerToGameButton.onClick.AddListener(HandleAddPlayerToGameButton);
        }

        private void HandleStartGameButton()
        {
            //oyunu başlat
        }

        private void HandleBackToMainPageButton()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.MAINMENU);
        }
        
        private void HandleAddPlayerButton()
        {
            topPanel.SetActive(false);
            mainPanel.SetActive(false);
            playerAddingPanel.SetActive(true);
        }
        private void HandleClosePlayerAddingPanelButton()
        {
            topPanel.SetActive(true);
            mainPanel.SetActive(true);
            playerAddingPanel.SetActive(false);
        }
        private void HandleAddPlayerToGameButton()
        {
            //oyuncuyu oyuna ekle
        }
        
    }
}

