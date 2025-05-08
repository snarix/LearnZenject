using UnityEngine;
using UnityEngine.UI;

public class InitializationUIRoot : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Set(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}