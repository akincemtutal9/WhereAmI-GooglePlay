using UnityEngine;

namespace GameAssets.Scripts.Utils
{
    public class UrlOpener : MonoBehaviour
    {
        public static void OpenUrl(string url)
        {
            Application.OpenURL(url);
        }
    }
}
