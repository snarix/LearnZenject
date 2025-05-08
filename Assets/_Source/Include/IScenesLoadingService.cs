using System;
using System.ComponentModel;
using _Source.MetaGameplay;
using UnityEngine.SceneManagement;
using Zenject;

namespace Include
{
    public enum SceneName
    {
        MainMenu,
        SampleScene
    }
    public interface IScenesLoadingService
    {
        void Load(SceneName sceneName);
        void LoadWithData<T>(SceneName sceneName, T data, Action callback = null);
    }

    public class ZenjectScenesLoadingService : IScenesLoadingService
    {
        private ZenjectSceneLoader _loader;

        public ZenjectScenesLoadingService(ZenjectSceneLoader loader)
        {
            _loader = loader;
        }

        public void Load(SceneName sceneName)
        {
            _loader.LoadScene(sceneName.ToString());
        }

        public void LoadWithData<T>(SceneName sceneName, T data, Action callback = null)
        {
            _loader.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single, container =>
            {
                container.BindInterfacesAndSelfTo<T>().FromInstance(data).AsSingle();
                //container.Bind<SceneTransitionData<T>>().FromInstance(new SceneTransitionData<T>(data)).AsSingle();
                callback?.Invoke();
            });
        }
    }

    public class SceneTransitionData<T>
    {
        private T _data;

        public SceneTransitionData(T data)
        {
            _data = data;
        }

        public T Data => _data;
    }
}