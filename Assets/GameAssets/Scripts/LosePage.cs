using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Player;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class LosePage : GameStateManagerProvider
    {
        [SerializeField] private Button playAgainButton;
        [SerializeField] private TMP_Text impostorNameText;
        protected override void Start()
        {
            var impostor = "";
            foreach (var imp in GameManager.Instance.GamePlayers)
            {
                if (imp.Role == Role.IMPOSTOR)
                {
                    impostor = imp.Name;
                }
            }
            base.Start();
            playAgainButton.onClick.AddListener(HandlePlayAgainButton);
            impostorNameText.text = "<color=yellow> " + GameManager.Instance.impostorName + " </color> was the impostor!";
        }
        
        private void HandlePlayAgainButton()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.MAINMENU);
            GameManager.Instance.ResetGame();
            GameManager.Instance.ResetVotes();
            GameManager.Instance.isItFirstGame = false;
        }
    }
}
