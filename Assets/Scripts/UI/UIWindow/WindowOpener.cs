using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowOpener : CustomUIElement
{
    [Header("Click")]
    [SerializeField] private float timeBeforeSecondClick = .3f;
    private Coroutine secondClickWait = null;

    [Header("Window")]
    [SerializeField] private UIWindow windowPrefab;
    [SerializeField] private Vector2 windowOpenLocation;
    [SerializeField] private Canvas windowParentCanvas;
    private UIWindow window = null;

    private void Awake()
    {
        window = null;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if(secondClickWait != null)
        {
            TryOpenWindow();
            secondClickWait = null;
            StopCoroutine(WaitForSecondClick());
        }
        else
            secondClickWait = StartCoroutine(WaitForSecondClick());
    }

    protected virtual IEnumerator WaitForSecondClick()
    {
        yield return new WaitForSecondsRealtime(timeBeforeSecondClick);

        secondClickWait = null;
        StopCoroutine(WaitForSecondClick());
    }

    protected virtual void TryOpenWindow()
    {
        if(window == null)
        {
            window = Instantiate(windowPrefab, windowParentCanvas.transform);
            window.SetParentCanvas(windowParentCanvas);
            window.Initialize();
            window.uiTransform.anchoredPosition = windowOpenLocation;
            window.OnCloseThisWindow += OnCloseWindow;
        }
    }

    protected virtual void OnCloseWindow(UIWindow closedWindow)
    {
        window = null;
    }
}
