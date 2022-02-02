using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserCalanderData
{
    public int DateDay = 0;
    public int DateMonthNumericPlacement = 0;
    public int DateYear = 0;
    public List<MonthSettingsNode> MonthNodes;

    public UserCalanderData(int dateDay, int dateMonth, int year, List<MonthSettingsNode> _nodes)
    {
        DateDay = dateDay;
        DateMonthNumericPlacement = dateMonth;
        DateYear = year;
        MonthNodes = _nodes;
    }
}
