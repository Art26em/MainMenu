using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

[RequireComponent(typeof(List<ButtonController>))]

public class ButtonEventsHandler : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.1f;
    [SerializeField] private float scaleDuration = 0.5f;
    [SerializeField] private List<ButtonController> buttons;
    
    private readonly Vector3 _baseScale = Vector3.one;
    
    private void OnEnable()
    {
        foreach (var button in buttons)
        {
            button.PointerEnter += ZoomInButton;
            button.PointerExit += ZoomOutButton;
        }
    }

    private void OnDisable()
    {
        foreach (var button in buttons)
        {
            button.PointerEnter -= ZoomInButton;
            button.PointerExit -= ZoomOutButton;
        }   
    }

    private void ZoomInButton(Transform buttonTransform)
    {
        Vector3 oldScale = _baseScale;
        Vector3 newScale = new Vector3(oldScale.x * scaleMultiplier, oldScale.y  * scaleMultiplier, oldScale.z);

        buttonTransform.DOScale(newScale, scaleDuration).SetEase(Ease.Linear);
    }
    
    private void ZoomOutButton(Transform buttonTransform)
    {
        buttonTransform.DOScale(_baseScale, scaleDuration).SetEase(Ease.Linear);         
    }
    
}
