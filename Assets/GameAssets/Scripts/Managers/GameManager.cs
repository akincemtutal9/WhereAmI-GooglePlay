using System.Collections.Generic;
using UnityEngine;

namespace GameAssets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance => instance;

        [SerializeField] private List<Player.Player> gamePlayers = new();
        [SerializeField] private List<string> placeList = new();
        
        public List<Player.Player> GamePlayers
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
        public void StartGame()
        {
            var place = placeList[Random.Range(0, placeList.Count)];
            var impostorIndex = Random.Range(0, gamePlayers.Count);

            foreach (var player in gamePlayers)
            {
                player.Role = player == gamePlayers[impostorIndex] ? Player.Role.IMPOSTOR : Player.Role.CREWMATE; // Rastgele bir oyuncuyu sahtekar olarak ayarlayın
                player.Place = player == gamePlayers[impostorIndex] ? "impostor" : place; // Impostor'a farklı place verme 
            }
        }
    }
}