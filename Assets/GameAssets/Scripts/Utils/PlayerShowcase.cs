using TMPro;
using UnityEngine;
namespace GameAssets.Scripts.Utils
{
    public class PlayerShowcase : MonoBehaviour
    {
        private Player player;
        public TMP_Text playerName;
        private void Update()// Update'i değiş bi ara
        {
            playerName.text = player.Name;
        }
    }
}
