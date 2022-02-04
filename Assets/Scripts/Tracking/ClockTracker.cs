using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockTracker : MonoBehaviour
{
    public StopWatch stopWatch;
    public Calander calander;
    DateTracker dateTracker;
    public TMP_InputField SecondsInput;
    public TMP_InputField MinutesInput;
    public TMP_InputField HoursInput;
    public TMP_Text ClockDisplay;
    private float secondTracker = 0;
    // Update is called once per frame

    private void Start()
    {
        dateTracker = calander.dateTracker;
    }

    public void LoadSaveData(UserClockData _userClockData)
    {
        Clock.Hour = _userClockData.ClockHours;
        Clock.Minute = _userClockData.ClockMinutes;
        Clock.Second = _userClockData.ClockSeconds;
        DisplayClock();
    }

    public void SetClock()
    {
        Clock.ZeroOut();
        ProcessClockInput();
    }

    public void ProcessClockInput()
    {
        addSeconds(int.Parse(SecondsInput.text));
        addMinutes(int.Parse(MinutesInput.text));
        addHours(int.Parse(HoursInput.text));
        DisplayClock();
    }

    void DisplayClock()
    {
        ClockDisplay.text = ((int)Clock.Hour).ToString() + ": " +
                                       ((int)Clock.Minute).ToString() + ": " +
                                       ((int)Clock.Second).ToString();
    }

    public void AddStopWatchToClock()
    {
        Vector3 _stopWatchTime = stopWatch.returnSecMinHour();
        addSeconds(_stopWatchTime.x);
        addMinutes(_stopWatchTime.y);
        addHours(_stopWatchTime.z);
        DisplayClock();
    }

    void addSeconds(float _sec)
    {
        Clock.Second += (int)_sec;
        if (Clock.Second > 60)
        {
            addMinutes(1f);
            Clock.Second -= 60;
        }
    }

    void addMinutes(float _minutes)
    {
        Clock.Minute += (int)_minutes;
        if (Clock.Minute > 60)
        {
            addHours(1f);
            Clock.Minute -= 60;
        }
    }

    void addHours(float _hours)
    {
        Clock.Hour += (int)_hours;
        if (Clock.Hour > 24)
        {
            dateTracker.TickNextDay();
            Clock.Hour -= 24;
        }
    }

    public void TickNextSecond()
    {
        addSeconds(1f);
        DisplayClock();
    }

    public void TickNextMinute()
    {
        addMinutes(1f);
        DisplayClock();
    }

    public void TickNextHour()
    {
        addHours(1f);
        DisplayClock();
    }

    public void InitializeClock(int _sec, int _minute, int _hour)
    {
        Clock.Second = _sec;
        Clock.Minute = _minute;
        Clock.Hour = _hour;
    }

}
