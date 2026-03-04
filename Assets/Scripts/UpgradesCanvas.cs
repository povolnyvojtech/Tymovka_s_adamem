using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradesCanvas : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Vector2 _offset;
    
    public GameObject houseManagerDisplay;
    public GameObject skillTreeDisplay;
    private bool _currentDisplayType; //true - houseManager, false - skillTree
    private bool _buttonPressed;
    public Button houseManagerButton;
    private Image _houseManagerButtonImageComponent;
    public Button skillTreeButton;
    private Image _skillTreeButtonImageComponent;
    
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _houseManagerButtonImageComponent = houseManagerButton.GetComponent<Image>();
        _skillTreeButtonImageComponent = skillTreeButton.GetComponent<Image>();
        houseManagerButton.onClick.AddListener((() => RefreshUI(true)));
        skillTreeButton.onClick.AddListener((() => RefreshUI(false)));
        RefreshUI(true);
    }

    public void RefreshUI(bool type)
    {
        if (type == _currentDisplayType) return;
        _currentDisplayType = !_currentDisplayType;
        switch (_currentDisplayType)
        {
            case true:
            {
                houseManagerDisplay.SetActive(true);
                _houseManagerButtonImageComponent.color = new Color(200, 200, 200);
                _skillTreeButtonImageComponent.color = new Color(255,255,255);
                skillTreeDisplay.SetActive(false); break;
            }
            case false:
            {
                skillTreeDisplay.SetActive(true); 
                _skillTreeButtonImageComponent.color = new Color(200, 200, 200);  
                _houseManagerButtonImageComponent.color = new Color(255,255,255);
                houseManagerDisplay.SetActive(false); break;
            }
        }
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
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            eventData.position,
            eventData.pressEventCamera,
            out var localPointerPos))
        {
            Vector2 targetPos = localPointerPos - _offset;
            float minX = canvasRect.rect.xMin + (_rectTransform.rect.width * _rectTransform.pivot.x);
            float maxX = canvasRect.rect.xMax - (_rectTransform.rect.width * (1 - _rectTransform.pivot.x));
            
            float minY = canvasRect.rect.yMin + (_rectTransform.rect.height * _rectTransform.pivot.y);
            float maxY = canvasRect.rect.yMax - (_rectTransform.rect.height * (1 - _rectTransform.pivot.y));

            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            _rectTransform.anchoredPosition = targetPos;
        }
    }
}