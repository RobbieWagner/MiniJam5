using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWindow : UIWindow
{
    [SerializeField] GameObject additionalContent;
    [SerializeField] InteractionTag interactionTag;

    protected override void Awake()
    {
        base.Awake();
        additionalContent.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(interactionTag.ToString()) && !additionalContent.activeSelf)
        {
            Destroy(other.gameObject);
            additionalContent.SetActive(true);
        }
    }
}
