using System.Collections.Generic;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;

namespace GameAssets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance => instance;
        [SerializeField] private TextMeshProUGUI totalCoinsText;
        [SerializeField] private List<Player.Player> gamePlayers = new();
        [SerializeField] private List<string> placeList = new();
        private const string placeListKey = "placeList";
        private const string coinKey = "totalCoins";
        public List<string> PlaceList
        {
            get => placeList;
            set => placeList = value;
        }

        [SerializeField] private List<Player.Player> backupPlayers = new();
    
        public bool isItFirstGame = true;
        
        public string impostorName = "";
        public List<Player.Player> GamePlayers
        {
            get => gamePlayers;
            set => gamePlayers = value;
        }
        public List<Player.Player> BackupPlayers
        {
            get => backupPlayers;
            set => backupPlayers = value;
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
        private void Start()
        {
            isItFirstGame = true;
            ShowCoins();
            LoadPlaceList();
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
            impostorName = gamePlayers[impostorIndex].Name;
        }
        public void ResetGame()
        {
            gamePlayers.Clear();
            gamePlayers.AddRange(backupPlayers);
        }

        public void ResetVotes()
        { 
            foreach (var player in backupPlayers)
            {
                player.VoteCount = 0;
            }
        }
        
        public void SavePlaceList()
        {
            PlayerPrefsExtra.SetList(placeListKey, placeList);
        }

        // PlayerPrefs'tan liste verisini yüklemek için
        private void LoadPlaceList()
        {
            placeList = PlayerPrefsExtra.GetList(placeListKey, placeList);
        }
        
        public void GrantCoins(int coin)
        {
            int crrCoin = PlayerPrefs.GetInt("totalCoins"); 
            crrCoin += coin;
            PlayerPrefs.SetInt(coinKey, crrCoin);

            ShowCoins();

        }
        public void SpendCoins(int coin)
        {
            int crrCoin = PlayerPrefs.GetInt("totalCoins"); 
            crrCoin -= coin;
            PlayerPrefs.SetInt(coinKey, crrCoin);

            ShowCoins();
        }
        private void ShowCoins()
        {
            totalCoinsText.text = PlayerPrefs.GetInt("totalCoins").ToString();
        }
        
    }
}