using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using UnityEngine.SceneManagement;  // Import for scene loading

public class Timerfor3 : MonoBehaviour
{
    public float TimeLeft = 10f;  // Set initial time (e.g., 10 seconds)
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;  // Reference to TextMeshPro for timer display

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure TimeLeft is positive at the start
        TimeLeft = Mathf.Max(120f, TimeLeft);  // Avoid any negative values for TimeLeft

        TimerOn = true;  // Start the timer immediately when the scene starts
        Debug.Log("Starting Timer with TimeLeft: " + TimeLeft);  // Log the initial value of TimeLeft
    }

    // Update is called once per frame
    void Update()
    {
        // Log the TimeLeft at the start of each frame to ensure it's being updated correctly
        Debug.Log("TimeLeft Before: " + TimeLeft);

        if (TimerOn)  // Only update the timer if it's active
        {
            if (TimeLeft > 0.1f)  // Ensure it doesn't change scene too early
            {
                TimeLeft -= Time.deltaTime;  // Countdown using real-time
                updateTimer(TimeLeft);  // Update the display
                Debug.Log("Time Left After: " + TimeLeft);  // Debugging time after decrement
            }
            else
            {
                // Time is up, load Scene 11
                Debug.Log("Time is Up!");
                TimeLeft = 0;  // Set time to 0
                TimerOn = false;  // Stop the countdown

                // Load Scene 11 (make sure Scene 11 is in your Build Settings)
                SceneManager.LoadScene(1);  // Change to the scene name or correct index number
            }
        }
    }

    // Update the timer display
    void updateTimer(float currentTime)
    {
        // Debug log to check the currentTime value
        Debug.Log("Current Time: " + currentTime);

        // Clamp current time to prevent negative values
        currentTime = Mathf.Max(0f, currentTime);

        // Display time in minutes and seconds
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);  // Display time in "MM : SS" format
    }
}