using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionIcon : FileIcon
{
    [SerializeField] private Image icon;
    [SerializeField] private Sprite nextSprite;
    [SerializeField] private IconTag tagToAdd;
    [SerializeField] private InteractionTag interactionTag;
    [SerializeField] private SwitchWindowOpener windowOpener;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(interactionTag.ToString()))
        {
            if(tagToAdd != IconTag.None) iconTags.Add(tagToAdd);
            icon.sprite = nextSprite;
            windowOpener.SwitchWindow(1);
        }
    }
}
