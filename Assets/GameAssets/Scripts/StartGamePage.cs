using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class StartGamePage : GameStateManagerProvider
    {
        [Header("Top Panel")]
        [SerializeField] private GameObject topPanel;
        [SerializeField] private Button backToMainPageButton;
        [SerializeField] private Button addPlayerButton;

        [Header("Main Panel")]
        [SerializeField] private GameObject mainPanel;

        [Header("Player Adding Panel")]
        [SerializeField] private GameObject playerAddingPanel;
        [SerializeField] private Button closePlayerAddingPanelButton;
        [SerializeField] private Button addPlayerToGameButton;
        [SerializeField] private TMP_InputField playerNameInputField;
        
        [Header("Player Edit Panel")]
        [SerializeField] private GameObject playerEditPanel;
        [SerializeField] private TMP_Text playerPlaceholderName;
        [SerializeField] private TMP_InputField playerNewName;
        [SerializeField] private Button updatePlayerButton;
        [SerializeField] private Button deletePlayerButton;
        [SerializeField] private Button closePlayerEditPanelButton;

        [Header("Main Panel Grid")]
        [SerializeField] private Transform playerGrid; // MainPanel'i ata
        [SerializeField] private GameObject playerUIPrefab; // PlayerShowcase'i bi dene
        
        [Header("BottomPanel")]
        [SerializeField] private GameObject bottomPanel;
        [SerializeField] private Button startGameButton;

        
        protected override void Start()
        {
            HandleClosePlayerAddingPanelButton();// Unutursak hieraarchy'de kodla kapatsın gereksiz uiları
            HandleClosePlayerEditPanelButton();
            base.Start();
            backToMainPageButton.onClick.AddListener(HandleBackToMainPageButton);
            addPlayerButton.onClick.AddListener(HandleAddPlayerButton);
            startGameButton.onClick.AddListener(HandleStartGameButton);
            closePlayerAddingPanelButton.onClick.AddListener(HandleClosePlayerAddingPanelButton);
            addPlayerToGameButton.onClick.AddListener(HandleAddPlayerToGameButton);
            closePlayerEditPanelButton.onClick.AddListener(HandleClosePlayerEditPanelButton);
            UpdatePlayerListUI();   
        }
        
        private void HandleStartGameButton()
        {
            if (GameManager.Instance.GamePlayers.Count < 3)
            {
                ErrorController.Instance.ShowError("You need at least 3 players to start the game!");
                return;
            }
            GameManager.Instance.StartGame();
            gameStateManager.SwitchGameState(GameStateManager.GameState.CHECKROLE);
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
            //Add Paneli kapat
            playerAddingPanel.SetActive(false);
            
            topPanel.SetActive(true);
            mainPanel.SetActive(true);
            bottomPanel.SetActive(true);
        }
        
        private void HandleClosePlayerEditPanelButton()
        {
            //
            playerEditPanel.SetActive(false);
            
            mainPanel.SetActive(true);
            topPanel.SetActive(true);
            bottomPanel.SetActive(true);

        }
        private void HandleAddPlayerToGameButton()
        {
            if (playerNameInputField.text == "")
            {
                ErrorController.Instance.ShowError("Player name cannot be empty!");
                return;
            }
            
            if (IsPlayerNameExists(playerNameInputField.text))
            {
                ErrorController.Instance.ShowError("Player name already exists!");
                return;
            }
            
            var player = new Player.Player(playerNameInputField.text);
            GameManager.Instance.GamePlayers.Add(player);
            playerNameInputField.text = "";
            HandleClosePlayerAddingPanelButton();
            UpdatePlayerListUI();
        }
        private void UpdatePlayerListUI()
        {
            //Gridi temizle sonra eklicez listedekileri
            foreach (Transform child in playerGrid)
            {
                Destroy(child.gameObject);
            }
            
            foreach (Player.Player player in GameManager.Instance.GamePlayers)
            {
                GameObject playerUI = Instantiate(playerUIPrefab, playerGrid, true);

                TMP_Text playerNameText = playerUI.GetComponentInChildren<TMP_Text>();
                playerNameText.text = player.Name;

                Button playerButton = playerUI.GetComponent<Button>();
                playerButton.onClick.AddListener(() => HandlePlayerButtonClick(player));
            }
        }
        private void HandlePlayerButtonClick(Player.Player player)
        {
            Debug.Log("Player clicked: " + player.Name);
            playerEditPanel.SetActive(true);
            topPanel.SetActive(false);
            mainPanel.SetActive(false);
            bottomPanel.SetActive(false);

            playerPlaceholderName.text = player.Name;

            updatePlayerButton.onClick.RemoveAllListeners(); // Temizle önceki dinleyicileri
            updatePlayerButton.onClick.AddListener(() => HandleUpdatePlayerButton(player));

            deletePlayerButton.onClick.RemoveAllListeners(); // Temizle önceki dinleyicileri
            deletePlayerButton.onClick.AddListener(() => HandleDeletePlayerButton(player));
        }

        private void HandleDeletePlayerButton(Player.Player player)
        {
            GameManager.Instance.GamePlayers.Remove(player);
            HandleClosePlayerEditPanelButton();
            UpdatePlayerListUI();
        }

        private void HandleUpdatePlayerButton(Player.Player player)
        {
            if (playerNewName.text == "")
            {
                ErrorController.Instance.ShowError("Player name cannot be empty!");
                return;
            }
            if (IsPlayerNameExists(playerNewName.text))
            {
                ErrorController.Instance.ShowError("Player name already exists!");
                return;
            }
            player.Name = playerNewName.text;
            HandleClosePlayerEditPanelButton();
            UpdatePlayerListUI();
            playerNewName.text = ""; // Boşalt burayı milletin kafası karışmasın
        }
        
        private bool IsPlayerNameExists(string playerName)
        {
            foreach (Player.Player player in GameManager.Instance.GamePlayers)
            {
                if (player.Name == playerName)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}

