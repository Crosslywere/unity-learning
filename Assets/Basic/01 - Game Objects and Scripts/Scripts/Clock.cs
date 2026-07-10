using System;
using UnityEngine;

namespace GameObjects
{
    public class Clock : MonoBehaviour
    {
        [SerializeField]
        private Transform hoursPivot, minutesPivot, secondsPivot;

        private const float hoursToDegrees = -30, minutesToDegrees = -6, secondsToDegrees = -6;

        // Is called when the component awakens
        void Awake()
        {
            Debug.Log(DateTime.Now);
        }


        // Update is called once per frame
        void Update()
        {
            // TimeOfDay
            var time = DateTime.Now.TimeOfDay;
            hoursPivot.localRotation = Quaternion.Euler(0, 0, hoursToDegrees * (float)time.TotalHours);
            minutesPivot.localRotation = Quaternion.Euler(0, 0, minutesToDegrees * (float)time.TotalMinutes);
            secondsPivot.localRotation = Quaternion.Euler(0, 0, secondsToDegrees * (float)time.TotalSeconds);
        }
    }
}
