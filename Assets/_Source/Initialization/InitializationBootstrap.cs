using System;
using System.Collections;
using Include;
using UnityEngine;
using Zenject;

public class InitializationBootstrap : IInitializable, IDisposable
{
    private IScenesLoadingService _scenesLoadingService;
    private ICoroutineHandler _coroutineHandler;
    private InitializationUIRoot _uiRoot;
    
    private Coroutine _coroutine;

    public InitializationBootstrap(IScenesLoadingService scenesLoadingService, ICoroutineHandler coroutineHandler, InitializationUIRoot uiRoot)
    {
        _scenesLoadingService = scenesLoadingService;
        _coroutineHandler = coroutineHandler;
        _uiRoot = uiRoot;
    }
    
    public void Initialize()
    {
        _coroutine = _coroutineHandler.StartCoroutine(InitializationRoutine());
    }
    
    public void Dispose()
    {
        if (_coroutine != null)
            _coroutineHandler.StopCoroutine(_coroutine);
    }
    
    private IEnumerator InitializationRoutine()
    {
        //Load Data Async
        ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>("Boom");
        yield return resourceRequest;
        _uiRoot.Set(resourceRequest.asset as Sprite);
        yield return new WaitForSeconds(1f);
        _scenesLoadingService.Load(SceneName.MainMenu);
    }
}