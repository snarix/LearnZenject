using System;
using UnityEngine;

public interface IInputSystem
{
    event Action<Vector3> Clicked;
    Vector3 CurrentPointerPosition { get; }
}