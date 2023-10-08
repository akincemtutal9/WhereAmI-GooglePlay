using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameAssets.Scripts
{
    public class VotePage : GameStateManagerProvider
    {
        [Header("Main Panel Grid")]
        [SerializeField] private Transform playerGrid;
        [SerializeField] private GameObject playerUIPrefab;

        [SerializeField] private Button voteButton;
        [SerializeField] private Button endVoteSessionButton;
        [SerializeField] private TMP_Text deviceTurnText;
        private Player.Player selectedPlayer;
        public int currentPlayerIndex = 0;

        protected override void Start()
        {
            endVoteSessionButton.gameObject.SetActive(false);
            ShowNextPlayerTurn();
            UpdatePlayerListUI();
            base.Start();

            voteButton.onClick.AddListener(HandleVoteButton);
            endVoteSessionButton.onClick.AddListener(HandleEndVoteSessionButton);
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
                playerButton.onClick.AddListener(() => SelectPlayer(player, playerButton));
            }
        }

        private void SelectPlayer(Player.Player player, Button button)
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
                return;
            }
            selectedPlayer.VoteCount++;
            currentPlayerIndex++;
            if (currentPlayerIndex >= GameManager.Instance.GamePlayers.Count)
            {
                endVoteSessionButton.gameObject.SetActive(true);
                voteButton.gameObject.SetActive(false);
            }
            else
            {
                selectedPlayer = null;
                ShowNextPlayerTurn();
            }
        }
        private void ShowNextPlayerTurn()
        {
            Player.Player nextPlayer = GameManager.Instance.GamePlayers[currentPlayerIndex];
            deviceTurnText.text = "Now it's <color=yellow>" + nextPlayer.Name + "'s turn to vote. Give device to "+ nextPlayer.Name + "</color>";
            UpdatePlayerListUI();
        }

        private void HandleEndVoteSessionButton()
        {
            CastOutHighestVotePlayer();
            UpdatePlayerListUI();
            currentPlayerIndex = 0;
            selectedPlayer = null;
            endVoteSessionButton.gameObject.SetActive(false);
            voteButton.gameObject.SetActive(true);
            gameStateManager.SwitchGameState(GameStateManager.GameState.DEBATE);
            ShowNextPlayerTurn();
        }
        
        private void CastOut(Player.Player player)
        {
            GameManager.Instance.GamePlayers.Remove(player);
        }

        private void CastOutHighestVotePlayer()
        {
            var highestVote = 0;
            var highestVotePlayer = new Player.Player("");
            foreach (var player in GameManager.Instance.GamePlayers)
            {
                if (player.VoteCount > highestVote)
                {
                    highestVote = player.VoteCount;
                    highestVotePlayer = player;
                }
            }
            CastOut(highestVotePlayer);
            InfoController.Instance.ShowInfo("<color=yellow>" + highestVotePlayer.Name + " is cast out!</color>");
            ResetVotes();
        }
        private void ResetVotes()
        {
            foreach (var player in GameManager.Instance.GamePlayers)
            {
                player.VoteCount = 0;
            }
        }
    }
}
