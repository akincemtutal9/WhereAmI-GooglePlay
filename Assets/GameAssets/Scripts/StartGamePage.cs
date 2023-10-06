using GameAssets.Scripts.Utils;
using TMPro;
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
        
        [SerializeField] private Transform playerGrid; // MainPanel'i ata
        [SerializeField] private GameObject playerUIPrefab; // PlayerShowcase'i bi dene
        
        protected override void Start()
        {
            HandleClosePlayerAddingPanelButton();// Unutursak hieraarchy'de kodla kapatsın gereksiz uiları
            
            base.Start();
            backToMainPageButton.onClick.AddListener(HandleBackToMainPageButton);
            addPlayerButton.onClick.AddListener(HandleAddPlayerButton);
            startGameButton.onClick.AddListener(HandleStartGameButton);
            closePlayerAddingPanelButton.onClick.AddListener(HandleClosePlayerAddingPanelButton);
            addPlayerToGameButton.onClick.AddListener(HandleAddPlayerToGameButton);
            
            UpdatePlayerListUI();   
        }
        private void HandleStartGameButton()
        {
            //oyunu başlat
            gameStateManager.SwitchGameState(GameStateManager.GameState.STARTGAME);
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
        private void UpdatePlayerListUI()
        {
            foreach (Player player in GameManager.Instance.GamePlayers)
            {
                GameObject playerUI = Instantiate(playerUIPrefab, playerGrid, true);

                TMP_Text playerNameText = playerUI.GetComponentInChildren<TMP_Text>();
                playerNameText.text = player.Name;

                Button playerButton = playerUI.GetComponent<Button>();
                playerButton.onClick.AddListener(() => HandlePlayerButtonClick(player));
            }
        }
        private void HandlePlayerButtonClick(Player player)
        {
            Debug.Log("Player clicked: " + player.Name);
        }
        
    }
}

