using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public bool unpaused = false;
    Vector3 secMinHour = Vector3.zero;
    public TMP_Text StopWatchDisplay;


    // Update is called once per frame
    void Update()
    {
        if (unpaused)
        {
            secMinHour.x += Time.deltaTime;
            DisplayTimer();
        }
    }

    public void DisplayTimer()
    {
        StopWatchDisplay.text = parseStopWatch();
    }

    string parseStopWatch()
    { 
        return ((int)secMinHour.z).ToString() + ": " +
                   ((int)secMinHour.y).ToString() + ": " +
                   ((int)secMinHour.x).ToString();
    }

    public void PauseTimer()
    {
        unpaused = !unpaused;
    }

    public void ResetTimer()
    {
        secMinHour = Vector3.zero;
    }

    public Vector3 returnSecMinHour()
    {

        if (secMinHour == Vector3.zero)
        {
            Debug.Log("Stop Watch is still zero");            
        }

        return secMinHour;

    }




}
