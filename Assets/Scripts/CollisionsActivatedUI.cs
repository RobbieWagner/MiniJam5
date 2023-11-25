using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActivatedUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject ui;
    private GameObject instantiatedUI;
    [SerializeField] private Vector2 parentOffset;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && instantiatedUI == null)
        {
            instantiatedUI = Instantiate(ui, canvas.transform);
            instantiatedUI.transform.position = (Vector2) transform.position + parentOffset;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && instantiatedUI != null)
        {
            Destroy(instantiatedUI);
            instantiatedUI = null;
        }
    }
}
