using UnityEngine;

namespace GameAssets.Scripts.Managers
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;

        public enum GameState
        {
            MAINMENU,
            STARTGAME,
            PLAYERLIBRARY,
            SETTINGS,
            DEBATE,
            VICTORY,
            VOTE,
            LOSE,
            CHECKROLE
        }

        [SerializeField] private GameState currentGameState; // Aktif game state'i saklayacak değişken

        [SerializeField] private GameObject mainMenuObject;
        [SerializeField] private GameObject playerLibraryObject;
        [SerializeField] private GameObject settingsObject;
        [SerializeField] private GameObject startGameObject;
        [SerializeField] private GameObject debateObject;
        [SerializeField] private GameObject victoryObject;
        [SerializeField] private GameObject voteObject;
        [SerializeField] private GameObject loseObject;
        [SerializeField] private GameObject checkRoleObject;

        private void Awake()
        {
            // Singleton örneği oluşturun
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Başlangıçta ana menüyü etkinleştirin
            SwitchGameState(GameState.MAINMENU);
        }
        public void SwitchGameState(GameState newGameState)
        {
            // Tüm game objectleri devre dışı bırakın
            mainMenuObject.SetActive(false);
            startGameObject.SetActive(false);
            playerLibraryObject.SetActive(false);
            settingsObject.SetActive(false);
            debateObject.SetActive(false);
            victoryObject.SetActive(false);
            voteObject.SetActive(false);
            loseObject.SetActive(false);
            checkRoleObject.SetActive(false);

            // Yeni game state'e göre sadece ilgili game objecti etkinleştirin
            switch (newGameState)
            {
                case GameState.MAINMENU:
                    mainMenuObject.SetActive(true);
                    break;
                case GameState.STARTGAME:
                    startGameObject.SetActive(true);
                    break;
                case GameState.PLAYERLIBRARY:
                    playerLibraryObject.SetActive(true);
                    break;
                case GameState.SETTINGS:
                    settingsObject.SetActive(true);
                    break;
                case GameState.DEBATE:
                    debateObject.SetActive(true);
                    break;
                case GameState.VICTORY:
                    victoryObject.SetActive(true);
                    break;
                case GameState.VOTE:
                    voteObject.SetActive(true);
                    break;
                case GameState.LOSE:
                    loseObject.SetActive(true);
                    break;
                case GameState.CHECKROLE:
                    checkRoleObject.SetActive(true);
                    break;
            }

            // Şu anki game state'i güncelle
            currentGameState = newGameState;
        }

        public GameState GetCurrentState()
        {
            return currentGameState;
        }
        
    }
}
