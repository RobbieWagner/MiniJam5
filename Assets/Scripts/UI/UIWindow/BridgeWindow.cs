using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeWindow : UIWindow
{
    private List<FileIcon> elementsCovered; 
    [SerializeField] private LayerMask ignoreLayers; 

    protected void Awake()
    {
        elementsCovered = new List<FileIcon>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        FileIcon element = other.GetComponent<FileIcon>();
        if(element != null && element.iconTags.Contains(IconTag.CanUseBridge) && !elementsCovered.Contains(element))
        {
            elementsCovered.Add(element);
            Debug.Log(element.gameObject.name);
            Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), other);
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        FileIcon element = other.GetComponent<FileIcon>();
        if(element != null && elementsCovered.Contains(element))
        {
            elementsCovered.Remove(element);
            Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), other, false);
        }
    }
}
