using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using RobbieWagnerGames;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public float gameSpeed = 1f;
    [SerializeField] public Canvas windowCanvas;
    private PlayerInputActions inputActions;
    public static GameManager Instance {get; private set;}

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

        inputActions = new PlayerInputActions();
    }

    private void OnResetLevel(InputValue inputValue)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
