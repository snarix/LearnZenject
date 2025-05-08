using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.MetaGameplay
{
    public class UIFacade : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _upgradesButton;
        
        [SerializeField] private Image _background;
        [SerializeField] private Button _backButton;
        
        public event Action PlayClicked;
        
        private void Start()
        {
            _playButton.onClick.AddListener(PlayClick);
            _upgradesButton.onClick.AddListener(UpgradeClick);
            _backButton.onClick.AddListener(BackClick);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(PlayClick);
            _upgradesButton.onClick.RemoveListener(UpgradeClick);
            _backButton.onClick.RemoveListener(BackClick);
        }
        
        private void PlayClick()
        {
            PlayClicked?.Invoke();
        }
        
        private void UpgradeClick()
        {
            _background.gameObject.SetActive(true);
        }
        
        private void BackClick()
        {
            _background.gameObject.SetActive(false);
        }
    }
}