using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnd;
    public Action<float> OnCountdownChange;

    [SerializeField] private float gameCountdown;
    [SerializeField] private bool gameRunning;
    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    private void Update()
    {
        if(gameCountdown >= 0 && gameRunning)
        {
            gameCountdown -= Time.deltaTime;
            OnCountdownChange?.Invoke(gameCountdown);

            if (gameCountdown < 0)
            {
                StopGame();
            }
        }


    }

    public void StartGame()
    {
        OnGameStart.Invoke();
        gameRunning = true;
    }

    public void StopGame()
    {
        gameRunning = false;
        OnGameEnd.Invoke();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
