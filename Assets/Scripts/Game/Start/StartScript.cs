using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class StartScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign this in the inspector
    private float startTime;
    private bool isTimerRunning = false;

    void Start()
    {
        // Start the timer
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2"); // 2 decimal places
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    // Add methods to stop or pause the timer as needed
}