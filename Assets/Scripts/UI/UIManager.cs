using UnityEngine;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    
    void Start()
    {
        GameManager.Singleton.OnCountdownChange += UpdateCountdown;
    }

    private void UpdateCountdown(float time)
    {
        TimeSpan formattedTime = new TimeSpan(0,0, (int)time);

        countdownText.text = formattedTime.Minutes + ":" + formattedTime.Seconds;
    }

    public void RestartButton()
    {
        GameManager.Singleton.RestartGame();
    }
}
