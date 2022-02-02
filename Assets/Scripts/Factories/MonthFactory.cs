using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class MonthFactory
{
    public static void AppendMonth(string _length, string _name, List<MonthSettingsNode> _monthList)
    {
        _monthList.Add(createMonth(_name, _length));
        linkNewMonth(_monthList);
    }

    static MonthSettingsNode createMonth(string _name, string _length)
    {
        return new MonthSettingsNode(_name, int.Parse(_length));
    }

    static void linkNewMonth(List<MonthSettingsNode> _monthList)
    {
        if (_monthList != null)
        {
            if (_monthList.Count > 1)
            {
                _monthList[_monthList.Count - 1].lastMonth = _monthList[_monthList.Count - 2];
                _monthList[_monthList.Count - 2].nextMonth = _monthList[_monthList.Count - 1];
                _monthList[_monthList.Count - 1].nextMonth = _monthList[0];
                _monthList[_monthList.Count - 1].numericPlacement = _monthList.Count;
            }
            else if(_monthList.Count == 1)
            {
                _monthList[_monthList.Count - 1].lastMonth = _monthList[_monthList.Count - 1];
                _monthList[_monthList.Count - 1].nextMonth = _monthList[_monthList.Count - 1];
                _monthList[_monthList.Count - 1].numericPlacement = _monthList.Count;
            }
        }
    } 
}
