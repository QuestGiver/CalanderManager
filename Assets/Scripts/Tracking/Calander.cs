using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calander : MonoBehaviour
{
    public DateTracker dateTracker;

    public Text DateDisplay;
    public Text MonthsDisplay;
    public Text ErrorDisplay;

    public InputField MonthInputName;
    public InputField MonthInputLength;

    public InputField DateDayInput;
    public InputField DateMonthInput;
    public InputField DateYearInput;

    // Start is called before the first frame update
    void Awake()
    {
        dateTracker = new DateTracker();
        dateTracker.PoolMonthSettingsList = new List<MonthSettingsNode>();
    }

    public void LoadSaveDate(UserCalanderData _userCalanderData)
    {
        dateTracker.PoolMonthSettingsList = _userCalanderData.MonthNodes;
        Date.day = _userCalanderData.DateDay;
        Date.month = dateTracker.PoolMonthSettingsList[_userCalanderData.DateMonthNumericPlacement-1];
        Date.year = _userCalanderData.DateYear;
        DisplayMonths();
        DisplayDate();
    }

    public void ProcessMonthInput()
    {
        MonthFactory.AppendMonth(MonthInputLength.text, MonthInputName.text, dateTracker.PoolMonthSettingsList);
        DisplayMonths();
    }

    void DisplayDate()
    {
        DateDisplay.text = Date.month.numericPlacement + "/" + Date.day + "/" + Date.year;
    }

    void DisplayMonths()
    {
        string newtext =  "";

        if (dateTracker.PoolMonthSettingsList.Count >= 1)
        {
            foreach (MonthSettingsNode month in dateTracker.PoolMonthSettingsList)
            {
                if (month == dateTracker.PoolMonthSettingsList[0])
                {
                    newtext += "Months: " + month.monthName;
                }
                else
                {
                    newtext += ", " + month.monthName;
                }
            }
        }

        MonthsDisplay.text = newtext;
    }

    public void InputDate()
    {
        ProcessDateInput(DateDayInput.textComponent.text, DateMonthInput.textComponent.text, DateYearInput.textComponent.text);
    }

    void ProcessDateInput(string _day, string _month, string _year)
    {
        int day = int.Parse(_day);
        int month = Mathf.Clamp( int.Parse(_month), 1, dateTracker.PoolMonthSettingsList.Count) - 1;
        int year = int.Parse(_year);

        if (validateDateInput(day, month))
        {
            GenerateDate(day, month, year);
            DisplayDate();
        }
        else 
        {
            ErrorDisplay.text = "Please Enter a Valid number for the Days Month and Year!";
        }

    }

    bool validateDateInput(int _day, int _month)
    {
        if (_month <= dateTracker.PoolMonthSettingsList.Count)
        {
            if (_day <= dateTracker.PoolMonthSettingsList[_month].DayCount)
            {
                return true;
            }
        }
        return false;
    }

    void GenerateDate(int _day, int _month, int _year)
    {
        dateTracker.InitializeDate(_day, dateTracker.PoolMonthSettingsList[_month], _year);
    }

    public void NextDay()
    {
        dateTracker.TickNextDay();
        DisplayDate();
    }

    public void NextMonth()
    {
        dateTracker.TickNextMonth();
        DisplayDate();
    }

    public void NextYear()
    {
        dateTracker.TickNextYear();
        DisplayDate();
    }
}
