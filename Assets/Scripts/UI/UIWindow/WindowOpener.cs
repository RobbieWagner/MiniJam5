using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowOpener : CustomUIElement
{
    [Header("Click")]
    [SerializeField] private float timeBeforeSecondClick = .3f;
    private Coroutine secondClickWait = null;

    [Header("Window")]
    [SerializeField] protected UIWindow windowPrefab;
    [SerializeField] private Vector2 windowOpenLocation;
    [SerializeField] private bool isLocationOffset = true;
    [SerializeField] protected Canvas windowParentCanvas;
    protected UIWindow window = null;

    protected override void Awake()
    {
        base.Awake();
        window = null;
        if(windowParentCanvas == null) windowParentCanvas = GameManager.Instance.windowCanvas;
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
        if(window == null && WindowManager.Instance.CanOpenWindow(window))
        {
            window = Instantiate(windowPrefab, windowParentCanvas.transform);
            window.SetParentCanvas(windowParentCanvas);
            window.Initialize();

            if(isLocationOffset) window.transform.position = transform.position + (Vector3) windowOpenLocation;
            else window.transform.position = windowOpenLocation;

            window.OnCloseThisWindow += OnCloseWindow;
            Debug.Log(window.gameObject.name);
        }
    }

    protected virtual void OnCloseWindow(UIWindow closedWindow)
    {
        window = null;
    }
}
