using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonthSettingsNode
{
    public MonthSettingsNode lastMonth;
    public MonthSettingsNode nextMonth;
    public string monthName = "";
    public int DayCount = 0;
    public int numericPlacement = 0;

    public MonthSettingsNode(string _name, int _dayCount)
    {
        monthName = _name;
        DayCount = _dayCount;

    }

    public MonthSettingsNode(int _dayCount)
    {
        DayCount = _dayCount;
    }
}
