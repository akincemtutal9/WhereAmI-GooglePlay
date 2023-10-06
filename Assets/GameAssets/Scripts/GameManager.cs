using System.Collections.Generic;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance => instance;

        [SerializeField] private List<Player> gamePlayers = new();

        public List<Player> GamePlayers
        {
            get => gamePlayers;
            set => gamePlayers = value;
        }

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
    }
}