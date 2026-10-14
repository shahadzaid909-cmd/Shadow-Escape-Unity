using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 120f;

    public Text timerText;
    public GameObject gameOverPanel;

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
