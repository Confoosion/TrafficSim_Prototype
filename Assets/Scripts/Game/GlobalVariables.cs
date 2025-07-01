using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class GlobalVariables
{
    public static float carSpeed = 0.2f;
    public static int jumps = 1;
    public static int distance = 0;
    public static int points = 0;
    public static int multiplier = 1;
    public static bool isDriving = true;
    public static bool isShielded = false;

    public static void AddJumps(int num)
    {
        jumps += num;
        UI_Script.instance.jumpsText.SetText(jumps.ToString());
    }
}
