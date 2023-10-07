using GameAssets.Scripts.Managers;
using UnityEngine;

namespace GameAssets.Scripts.Utils
{
    public class GameStateManagerProvider : MonoBehaviour
    {
        protected GameStateManager gameStateManager;
        protected virtual void Start()
        {
            gameStateManager = GameStateManager.Instance;
        }
    }
}
