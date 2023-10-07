using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class CheckRolePage : GameStateManagerProvider
    {
        [Header("Top Panel")]
        [SerializeField] private Button backButton;
        [SerializeField] private TMP_Text deviceTurnText; // Üstte yazan cihazı şuna ver buna ver muhabbeti
        
        [Header("Enterance Panel")]
        [SerializeField] private GameObject enterancePanel;
        [SerializeField] private Button enteranceButton;

        [Header("Main Panel")]
        [SerializeField] private Button showRoleButton;
        [SerializeField] private Button checkRoleButton;
        [SerializeField] private TMP_Text rolePlaceText;
        
        
        [Header("Bottom Panel")]
        [SerializeField] private Button nextPlayerButton; // Bu buton aynı zamanda bu kısmı bitirecek btw ona göre
        private int currentPlayerIndex = 0;
        
        protected override void Start()
        {
            ResetChecking();
            base.Start();
            backButton.onClick.AddListener(HandleBackButton);
            showRoleButton.onClick.AddListener(HandleShowRoleButton);
            checkRoleButton.onClick.AddListener(HandleCheckRoleButton);
            nextPlayerButton.onClick.AddListener(HandleNextPlayerButton);
            enteranceButton.onClick.AddListener(HandleEnteranceButton);
        }

        private void ResetChecking()
        {
            checkRoleButton.gameObject.SetActive(false);
            rolePlaceText.gameObject.SetActive(false);
            nextPlayerButton.gameObject.SetActive(false);
        }
        private void HandleBackButton()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.STARTGAME);
        }
        private void HandleEnteranceButton()
        {
            enterancePanel.gameObject.SetActive(false);
            HandleNextPlayerButton();
        }
        private void HandleShowRoleButton()
        {
            checkRoleButton.gameObject.SetActive(true);
        }
        private void HandleCheckRoleButton()
        {
            rolePlaceText.gameObject.SetActive(true);
            nextPlayerButton.gameObject.SetActive(true);
        }
        private void HandleNextPlayerButton()
        {
            if (currentPlayerIndex < GameManager.Instance.GamePlayers.Count)
            {
                var player = GameManager.Instance.GamePlayers[currentPlayerIndex];
                ResetChecking();
                deviceTurnText.text = "Now it's <color=yellow>" + player.Name +
                                      "</color>'s turn. Give Device to <color=yellow>" + player.Name +
                                      " </color>";
                CheckPlayerRole(player);
                currentPlayerIndex++;
                if (currentPlayerIndex == GameManager.Instance.GamePlayers.Count)
                {
                    nextPlayerButton.GetComponentInChildren<TMP_Text>().text = "Start Debate";
                }
            }
            else
            {
                gameStateManager.SwitchGameState(GameStateManager.GameState.DEBATE);
            }
        }

        private void CheckPlayerRole(Player.Player player)
        {
            rolePlaceText.text = "<color=yellow>" + player.Place + "</color>";
        }
    }
}
