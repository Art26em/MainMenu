using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<Transform> PointerEnter;
    public event Action<Transform> PointerExit;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnter?.Invoke(transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExit?.Invoke(transform);
    }
}
