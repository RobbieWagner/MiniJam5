using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public float gameSpeed = 1f;
    public static GameManager Instance {get; private set;}
    [SerializeField] public Canvas windowCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}
