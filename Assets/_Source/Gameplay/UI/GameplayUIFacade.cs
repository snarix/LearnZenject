using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Gameplay.UI
{
    public class GameplayUIFacade : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        
        public event Action BackButtonClicked;
        
        private void Start()
        {
            _backButton.onClick.AddListener(BackInMainMenu);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(BackInMainMenu);
        }

        private void BackInMainMenu()
        {
            BackButtonClicked?.Invoke();
        }
    }
}