using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Clock
{
    public static int Hour;
    public static int Minute;
    public static int Second;

    public static void ZeroOut()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
    }
}
