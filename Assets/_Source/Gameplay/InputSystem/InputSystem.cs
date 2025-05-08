using System;
using UnityEngine;
using Zenject;

public class InputSystem : IInputSystem, ITickable
{
    private Camera _camera;
    private LayerMask _layerMask;

    public InputSystem(Camera camera, LayerMask layerMask)
    {
        _camera = camera;
        _layerMask = layerMask;
    }
    
    public event Action<Vector3> Clicked;
    public Vector3 CurrentPointerPosition { get; private set; }
    
    public void Tick()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            if (Input.GetMouseButtonDown(0))
                Clicked?.Invoke(hit.point);
            
            CurrentPointerPosition = hit.point;
        }
    }
}