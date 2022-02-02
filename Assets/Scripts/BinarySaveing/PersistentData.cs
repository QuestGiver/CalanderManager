using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentData
{
    public UserCalanderData calanderData;
    public UserClockData clockData;

    public PersistentData(UserCalanderData _userCalanderData, UserClockData _userClockData)
    {
        calanderData = _userCalanderData;
        clockData = _userClockData;
    }
}
