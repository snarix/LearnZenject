using _Source.Gameplay.PlayerShooter;
using _Source.Gameplay.UI;
using Include;
using UnityEngine;
using Zenject;

namespace _Source.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private GameplayUIFacade _gameplayUIFacade;
        private IScenesLoadingService _scenesLoadingService;
        
        [Inject]
        public void Construct(IScenesLoadingService scenesLoadingService)
        {
            _scenesLoadingService = scenesLoadingService;
        }

        private void Start()
        {
            _gameplayUIFacade.BackButtonClicked += OnBackButtonClicked;
        }
        
        private void OnDestroy()
        {
            _gameplayUIFacade.BackButtonClicked -= OnBackButtonClicked;
        }

        private void OnBackButtonClicked()
        {
            _scenesLoadingService.Load(SceneName.MainMenu);
        }
    }
}