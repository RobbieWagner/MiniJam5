using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public enum IconTag
{
    None = 0,
    Default = 1,
    CanUseBridge = 2,
}

public enum InteractionTag
{
    None,
    FillCups,
    NeedsWater,
}

public class FileIcon : MonoBehaviour
{
    public Collider2D iconCollider;
    public List<IconTag> iconTags;

    public void TryTurnCollisionsBackOn()
    {
        //TODO figure out how to prevent the collider from being turned back on if the player is on top
    }
}
