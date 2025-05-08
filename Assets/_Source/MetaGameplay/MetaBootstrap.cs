using _Source.Gameplay.PlayerShooter;
using Include;
using UnityEngine;
using Zenject;

namespace _Source.MetaGameplay
{
    public class MetaBootstrap : MonoBehaviour
    {
        [SerializeField] private UIFacade _uiFacade;
        private IScenesLoadingService _loadingService;
        private PlayerStats _playerStats;
        
        [Inject]
        public void Construct(IScenesLoadingService loadingService, PlayerStats playerStats)
        {
            _loadingService = loadingService;
            _playerStats = playerStats;
        }
        
        private void Start()
        {
            _uiFacade.PlayClicked += OnPlayClicked;
        }
        
        private void OnDestroy()
        {
            _uiFacade.PlayClicked -= OnPlayClicked;
        }
        
        private void OnPlayClicked()
        {
            
            _loadingService.LoadWithData<PlayerStats>(SceneName.SampleScene, _playerStats);
        }
    }
}