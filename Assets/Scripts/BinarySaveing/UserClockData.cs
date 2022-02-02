using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserClockData
{
    public int ClockSeconds = 0;
    public int ClockMinutes = 0;
    public int ClockHours = 0;

    public UserClockData(int _seconds, int _minutes, int _hours)
    {
        ClockSeconds = _seconds;
        ClockMinutes = _minutes;
        ClockHours = _hours;
    }
}
