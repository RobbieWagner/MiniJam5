using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowContent: MonoBehaviour 
{
    public CustomUIElement uiElement;
    public float padding;

    public virtual void FormatContent(RectTransform windowTransform, float borderSize, float topBarHeight)
    {
        uiElement.uiTransform.sizeDelta = new Vector2(windowTransform.sizeDelta.x-borderSize*2 - padding, windowTransform.sizeDelta.y-borderSize*2-(topBarHeight-7f) - padding);
        uiElement.uiTransform.anchoredPosition = new Vector2(0, borderSize); 
    }
}