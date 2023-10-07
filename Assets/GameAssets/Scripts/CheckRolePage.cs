using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class CheckRolePage : GameStateManagerProvider
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TMP_Text deviceTurnText; // Üstte yazan cihazı şuna ver buna ver muhabbeti
        
        
        [SerializeField] private Button showRoleButton;
        [SerializeField] private Button checkRoleButton;
        [SerializeField] private TMP_Text rolePlaceText;
        
        
        [SerializeField] private Button nextPlayerButton; // Bu buton aynı zamanda bu kısmı bitirecek btw ona göre
        private int currentPlayerIndex = 0;
        protected override void Start()
        {
            HandleNextPlayerButton();// Bi tur ilerletiyorum burda güzel başlıyo sarıyo
            
            base.Start();
            backButton.onClick.AddListener(HandleBackButton);
            showRoleButton.onClick.AddListener(HandleShowRoleButton);
            checkRoleButton.onClick.AddListener(HandleCheckRoleButton);
            nextPlayerButton.onClick.AddListener(HandleNextPlayerButton);
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
                deviceTurnText.text = "Now it's " + player.Name + "'s turn. Give Device to " + player.Name; // Cihazın sırasını göster
                CheckPlayerRole(player);
                currentPlayerIndex++;
            }
            else
            {
                gameStateManager.SwitchGameState(GameStateManager.GameState.DEBATE);
            }
        }

        private void CheckPlayerRole(Player.Player player)
        {
            rolePlaceText.text = player.Name + " is " + player.Role + " and " + player.Place;
        }
    }
}
