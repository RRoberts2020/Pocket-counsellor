using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaliyRest : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    private void Start()
    {
        // Start the timer loop
        InvokeRepeating(nameof(UpdateTimer), 0f, 1f); // Update every second
    }

    private void UpdateTimer()
    {
        // Calculate time until next midnight
        DateTime now = DateTime.Now;
        DateTime midnight = now.Date.AddDays(1); // Next midnight
        TimeSpan timeUntilMidnight = midnight - now;

        // Update TextMeshPro with countdown
        countdownText.text = $"Time Until New Day: {timeUntilMidnight.Hours:00}:{timeUntilMidnight.Minutes:00}:{timeUntilMidnight.Seconds:00}";

        // Check if it's midnight to trigger notification
        if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
        {
            TriggerNotification("It's the dawn of a new day", "Time to look at your daliy tasks");
        }
    }

    private void TriggerNotification(string title, string message)
    {
        // Add code here to trigger local notifications for Android/iOS
        // For Android, you can use Android Native or Unity's AndroidJavaClass
        // For iOS, use Unity's UnityEngine.iOS.NotificationServices

        // Example for Android:
        //AndroidNotificationCenter.SendNotification(new AndroidNotification(title, message, DateTime.Now.AddSeconds(1)));
    }
}
