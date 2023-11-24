using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopupWindow : UIWindow
{
    protected override void Awake()
    {
        StartCoroutine(OpenPopup());
    }

    private IEnumerator OpenPopup()
    {
        SetWindowInteractability(false);
        yield return null;
        SetWindowInteractability(true);
        base.Awake();
        StopCoroutine(OpenPopup());
    }
}
