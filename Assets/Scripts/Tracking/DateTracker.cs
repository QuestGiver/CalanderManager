using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[System.Serializable]
public class DateTracker
{
    public Calander calander;
    protected List<MonthSettingsNode> poolMonthSettingsList = new List<MonthSettingsNode>();

    public List<MonthSettingsNode> PoolMonthSettingsList
    {
        get
        {
            return poolMonthSettingsList;
        }
        set
        {
            poolMonthSettingsList = value;
        }
    }

    public void InitializeDate(int _day, MonthSettingsNode _month, int _year)
    {
        Date.day = _day;
        Date.month = _month;
        Date.year = _year;
    }

    public void TickNextMonth()
    {
        if (poolMonthSettingsList.Count > 1)
        {
            if (Date.month.nextMonth == poolMonthSettingsList[0])
            {
                Date.year++;
                calander.DisplayDate();
            }
            Date.month = Date.month.nextMonth;
        }
    }

    public void TickNextDay()
    {
        if (Date.month != null)
        {
            if (Date.month.DayCount > 1)
            {
                if ((Date.day + 1) > Date.month.DayCount)
                {
                    TickNextMonth();
                    Date.day = 1;
                    calander.DisplayDate();
                }
                else
                {
                    Date.day++;
                    calander.DisplayDate();
                }
            }
            
        }
    }

    public void TickNextYear()
    {
        Date.year += 1;
        calander.DisplayDate();
    }

}
