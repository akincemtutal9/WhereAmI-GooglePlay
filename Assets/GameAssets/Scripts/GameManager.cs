using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        
        public static GameManager Instance => instance;

        [SerializeField] private List<Player> gamePlayers = new();

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                var playerName = "Player " + (i + 1);
                var playerRole = Role.CREWMATE;
                var playerVoteCount = 0;
                gamePlayers.Add(new Player(playerName, playerRole, playerVoteCount));
            }
        }
    }
}