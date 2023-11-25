using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    [SerializeField] private Vector2 offset;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CenterCameraAtPoint();
        }
    }

    private void CenterCameraAtPoint()
    {
        Camera.main.transform.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y,Camera.main.transform.position.z);
    }
}
