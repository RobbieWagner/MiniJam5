using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIWindow : CustomUIElement
{
    [SerializeField] private Canvas parentCanvas;
    private RectTransform parentCanvasT;
    [SerializeField] private CustomUIElement topBar;
    [SerializeField] private CustomUIElement closeWindow;
    [SerializeField] private List<WindowContent> windowContent;
    [SerializeField] private float CLOSE_WINDOW_SIZE = 20f;
    [SerializeField] private float BORDER_SIZE = 2f;
    private readonly float TOP_BAR_HEIGHT = 23.5f;

    #region events
    private bool canMove = false;
    public bool CanMove
    {
        get 
        {
            return canMove;
        }
        set
        {
            if(canMove == value) return;
            canMove = value;
            OnCanMoveChanged?.Invoke(canMove);
        }
    }
    public delegate void OnCanMoveChangedDelegate(bool canWindowMove);
    public event OnCanMoveChangedDelegate OnCanMoveChanged;

    private bool canClose = false;
    public bool CanClose
    {
        get 
        {
            return canClose;
        }
        set
        {
            if(canClose == value) return;
            canClose = value;
            OnCanCloseChanged?.Invoke(canClose);
        }
    }
    public delegate void OnCanCloseChangedDelegate(bool canCloseWindow);
    public event OnCanCloseChangedDelegate OnCanCloseChanged;

    private bool movingWindow = false;
    public bool MovingWindow
    {
        get 
        {
            return movingWindow;
        }
        set
        {
            if(movingWindow == value) return;
            movingWindow = value;
            OnMovingWindowChanged?.Invoke(movingWindow);
        }
    }
    public delegate void OnMovingWindowChangedDelegate(bool moving);
    public event OnMovingWindowChangedDelegate OnMovingWindowChanged;
    #endregion

    private Vector2 distanceMouseToWindow;

    protected virtual void Awake()
    {
        if(parentCanvas != null)
            Initialize();
    }

    public virtual void Initialize()
    {
        parentCanvasT = parentCanvas.GetComponent<RectTransform>();

        topBar.uiTransform.sizeDelta = new Vector2(uiTransform.sizeDelta.x - CLOSE_WINDOW_SIZE, TOP_BAR_HEIGHT);
        closeWindow.uiTransform.sizeDelta = new Vector2(CLOSE_WINDOW_SIZE, CLOSE_WINDOW_SIZE);

        foreach(WindowContent w in windowContent)
            w.FormatContent(uiTransform, BORDER_SIZE, TOP_BAR_HEIGHT);

        distanceMouseToWindow = Vector2.zero;

        if(topBar != null) 
        {
            topBar.OnMouseOverChanged += OnHoverTopBar;
            topBar.OnLMBClicked += OnDragWindow;
            topBar.OnLMBReleased += OnReleaseWindow;
        }
        if(closeWindow != null)
        {
            closeWindow.OnMouseOverChanged += OnHoverCloseWindow;
            closeWindow.OnLMBClicked += OnCloseWindow;
        }
    }

    private void Update()
    {
        if(movingWindow) uiTransform.anchoredPosition = (Vector2) Input.mousePosition - distanceMouseToWindow;
    }

    private void LateUpdate()
    {
        Vector2 pos = uiTransform.anchoredPosition;

        pos.x = Mathf.Clamp(pos.x, 0 - uiTransform.sizeDelta.x/2, parentCanvasT.sizeDelta.x - uiTransform.sizeDelta.x/2);
        pos.y = Mathf.Clamp(pos.y, 0 - uiTransform.sizeDelta.y*4/5, parentCanvasT.sizeDelta.y - uiTransform.sizeDelta.y);

        uiTransform.anchoredPosition = pos;
    }

    protected virtual void OnHoverTopBar(bool isMouseOver)
    {
        CanMove = isMouseOver;
        // if(CanMove) Debug.Log("mouse over top bar");
        // else 
        // {
        //     //OnReleaseWindow();
        //     Debug.Log("mouse not over top bar");
        // }
    }

    protected virtual void OnHoverCloseWindow(bool isMouseOver)
    {
        CanClose = isMouseOver;
        //if(CanClose) Debug.Log("mouse over close window");
        //else Debug.Log("mouse not over close window");
    }

    protected virtual void OnDragWindow()
    {
        MovingWindow = true;
        distanceMouseToWindow = (Vector2) Input.mousePosition - uiTransform.anchoredPosition;
        transform.SetAsLastSibling();
    }

    protected virtual void OnReleaseWindow()
    {
        MovingWindow = false;
    }

    protected virtual void OnCloseWindow()
    {
        OnCloseThisWindow?.Invoke();
        Destroy(this.gameObject);
    }
    public delegate void OnCloseWindowDelegate();
    public event OnCloseWindowDelegate OnCloseThisWindow;

    protected virtual void SetWindowInteractability(bool isInteractable)
    {
        topBar.enabled = isInteractable;
        closeWindow.enabled = isInteractable;
    }

    public void SetParentCanvas(Canvas canvas)
    {
        parentCanvas = canvas;
    }
}
