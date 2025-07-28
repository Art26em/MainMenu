using UnityEngine;
using DG.Tweening;

public class ButtonEventsHandler : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.1f;
    [SerializeField] private float scaleDuration = 0.5f;
    
    private readonly Vector3 _baseScale = Vector3.one;
    
    private void OnEnable()
    {
        ButtonController.PointerEnter += ZoomInButton;                    
        ButtonController.PointerExit += ZoomOutButton;                    
    }

    private void OnDisable()
    {
        ButtonController.PointerEnter -= ZoomInButton;                    
        ButtonController.PointerExit -= ZoomOutButton;    
    }

    private void ZoomInButton(Transform buttonTransform)
    {
        Vector3 oldScale = buttonTransform.localScale;
        Vector3 newScale = new Vector3(oldScale.x * scaleMultiplier, oldScale.y  * scaleMultiplier, oldScale.z);

        buttonTransform.DOScale(newScale, scaleDuration).SetEase(Ease.Linear);
    }
    
    private void ZoomOutButton(Transform buttonTransform)
    {
        buttonTransform.DOScale(_baseScale, scaleDuration).SetEase(Ease.Linear);         
    }
    
}
