using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class DebatePage : GameStateManagerProvider
    {
        [SerializeField] private Button voteButton;

        protected override void Start()
        {
            base.Start();
            voteButton.onClick.AddListener(HandleVoteButton);
        }
        private void HandleVoteButton()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.VOTE);
        }
        
    }
}
