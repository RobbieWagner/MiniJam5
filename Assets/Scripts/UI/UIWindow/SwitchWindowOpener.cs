using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWindowOpener : WindowOpener
{
    [SerializeField] List<UIWindow> possibleWindows;

    protected override void Awake()
    {
        windowPrefab = possibleWindows[0];
        window = null;
        if(windowParentCanvas == null) windowParentCanvas = GameManager.Instance.windowCanvas;
    }

    public void SwitchWindow(int index)
    {
        if(index < possibleWindows.Count) windowPrefab = possibleWindows[index];
    }
}
