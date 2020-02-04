using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //Player
    public bool[] PlayerInitStates;
    public float PlayerInitSpeed;
    public float PlayerFootSpeed;
    public int PlayerBlindLevel;
    public int PlayerBreakConstant;
    public int PlayerMaxBreakProbability;

    //RobotDown
    public bool[] RobotDownInitStates;

    //Item
    public float ConveyorSpeed;
    public float ItemSpanSpace;
    public float NeedItemIncrease;

    //Timer
    public int MaxBatteryTime;
}
