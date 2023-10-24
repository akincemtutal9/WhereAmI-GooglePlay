using GameAssets.Scripts.Managers;
using GameAssets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class LibraryPage : GameStateManagerProvider
    {
        [Header("placeCost")]
        [SerializeField] private int placeCost = 50;
               
        [Header("Top Panel")]
        [SerializeField] private GameObject topPanel;
        [SerializeField] private Button addPlaceButton;
        [SerializeField] private Button backButton;

        [Header("Main Panel")]
        [SerializeField] private GameObject mainPanel;
        
        [Header("Main Panel Grid - Content")]
        [SerializeField] private Transform placeGrid;
        [SerializeField] private GameObject placeUIPrefab;
        
        [Header("Add Place Panel")]
        [SerializeField] private GameObject addPlacePanel;
        [SerializeField] private TMP_InputField addPlaceInputField;
        [SerializeField] private Button addPlace;
        [SerializeField] private Button closeAddPlacePanelButton;

        protected override void Start()
        {
            base.Start();
            backButton.onClick.AddListener(HandleBackButton);
            addPlaceButton.onClick.AddListener(HandleAddPlaceButton);
            addPlace.onClick.AddListener(HandleAddPlace);
            closeAddPlacePanelButton.onClick.AddListener(HandleCloseAddPlacePanelButton);
            
            UpdatePlaceListUI();
        }
        private void HandleBackButton()
        {
            gameStateManager.SwitchGameState(GameStateManager.GameState.MAINMENU);
        }
        private void HandleAddPlaceButton()
        {
            topPanel.SetActive(false);
            mainPanel.SetActive(false);
            addPlacePanel.SetActive(true);
        }
        private void HandleCloseAddPlacePanelButton()
        {
            addPlacePanel.SetActive(false);
            topPanel.SetActive(true);
            mainPanel.SetActive(true);
        }
        private void HandleAddPlace()
        {
            if (HasEnoughMoney())
            {
                var placeName = addPlaceInputField.text;
                if (placeName == "")
                {
                    ErrorController.Instance.ShowError("You can't add an empty place!");
                    return;
                }

                if (IsPlaceExist())
                {
                    ErrorController.Instance.ShowError("This place already exists!");
                    return;
                }

                GameManager.Instance.PlaceList.Add(placeName);
                GameManager.Instance.SpendCoins(placeCost);
                InfoController.Instance.ShowInfo(placeName + " added to list!");
                UpdatePlaceListUI();
                HandleCloseAddPlacePanelButton();
                addPlaceInputField.text = "";
                GameManager.Instance.SavePlaceList();
            }
            else
            {
                ErrorController.Instance.ShowError("You don't have enough money to add a place!");
            }
        }

        private void UpdatePlaceListUI()
        {
            // Gridi temizle ve listedekileri ekle
            foreach (Transform child in placeGrid)
            {
                Destroy(child.gameObject);
            }

            foreach (string place in GameManager.Instance.PlaceList)
            {
                GameObject playerUI = Instantiate(placeUIPrefab, placeGrid, false);

                TMP_Text placeNameText = playerUI.transform.GetChild(0).GetComponent<TMP_Text>();
                placeNameText.text = place;
            }
        }
        private bool HasEnoughMoney()
        {
            var money = PlayerPrefs.GetInt("totalCoins");
            if (money >= placeCost)
            {
                return true;
            }
            return false;
        }
        private bool IsPlaceExist()
        {
            var placeName = addPlacePanel.GetComponentInChildren<TMP_InputField>().text;
            foreach (var place in GameManager.Instance.PlaceList)
            {
                if (place == placeName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
