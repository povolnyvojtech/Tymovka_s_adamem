using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggablePanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Vector2 _offset;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out var localMousePos
        );
        
        _offset = localMousePos - _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_canvas == null) return;

        RectTransform canvasRect = _canvas.transform as RectTransform;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, eventData.pressEventCamera, out var localPointerPos))
        {
            Vector2 targetPos = localPointerPos - _offset;

            float minX = canvasRect.rect.xMin + ((_rectTransform.rect.width * _rectTransform.pivot.x) / 8);
            float maxX = canvasRect.rect.xMax - ((_rectTransform.rect.width * _rectTransform.pivot.x) / 8);
            float minY = canvasRect.rect.yMin + ((_rectTransform.rect.height * _rectTransform.pivot.y)/6);
            float maxY = canvasRect.rect.yMax - (_rectTransform.rect.height * _rectTransform.pivot.y);

            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            _rectTransform.anchoredPosition = targetPos;
        }
    }
}