using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class VotePage : GameStateManagerProvider
    {
        [Header("Main Panel Grid")]
        [SerializeField] private Transform playerGrid;
        [SerializeField] private GameObject playerUIPrefab;

        [SerializeField] private Button voteButton;
        private Player.Player selectedPlayer;
        protected override void Start()
        {
            UpdatePlayerListUI();
            base.Start();
            
            voteButton.onClick.AddListener(HandleVoteButton);
        }

        private void UpdatePlayerListUI()
        {
            // Gridi temizle ve listedekileri ekle
            foreach (Transform child in playerGrid)
            {
                Destroy(child.gameObject);
            }

            foreach (Player.Player player in GameManager.Instance.GamePlayers)
            {
                GameObject playerUI = Instantiate(playerUIPrefab, playerGrid, true);

                TMP_Text playerNameText = playerUI.transform.GetChild(0).GetComponent<TMP_Text>();
                playerNameText.text = player.Name;

                Button playerButton = playerUI.GetComponent<Button>();
                playerButton.onClick.AddListener(() => SelectPlayer(player,playerButton));
                
            }
        }
        private void SelectPlayer(Player.Player player,Button button)
        {
            foreach (Transform child in playerGrid)
            {
                child.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
            }
            button.transform.GetChild(1).GetComponent<TMP_Text>().text = "Selected";
            selectedPlayer = player;
        }

        private void HandleVoteButton()
        {
            if (selectedPlayer == null)
            {
                ErrorController.Instance.ShowError("Please select a player to vote!");
            }
            else
            {
                selectedPlayer.VoteCount++;
            }
        }
        
    }
}
