using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Data data;
    public Main main;

    public void EasyMode()
    {
        data.PlayerInitStates = new bool[] { true, true, true, true, true, true };
        data.PlayerInitSpeed = 2f;
        data.PlayerFootSpeed = 1f;
        data.PlayerBlindLevel = 120;
        data.PlayerBreakConstant = 3;
        data.PlayerMaxBreakProbability = 50;

        data.RobotDownInitStates = new bool[] { true, true, true, true, true, false };

        data.ConveyorSpeed = 1f;
        data.ItemSpanSpace = 2f;
        //data.NeedItemIncrease = 50;

        data.MaxBatteryTime = 40;
        gameObject.SetActive(false);

        main.SelectedDifficulty = true;
    }

    public void NormalMode()
    {
        data.PlayerInitStates = new bool[] { true, true, true, true, true, true };
        data.PlayerInitSpeed = 2f;
        data.PlayerFootSpeed = 1f;
        data.PlayerBlindLevel = 120;
        data.PlayerBreakConstant = 3;
        data.PlayerMaxBreakProbability = 50;

        data.RobotDownInitStates = new bool[] { true, true, true, true, true, false };

        data.ConveyorSpeed = 1f;
        data.ItemSpanSpace = 2f;
        //data.NeedItemIncrease = 50;

        data.MaxBatteryTime = 40;
        gameObject.SetActive(false);

        main.SelectedDifficulty = true;
    }

    public void HardMode()
    {
        data.PlayerInitStates = new bool[] { true, true, true, true, true, true };
        data.PlayerInitSpeed = 2f;
        data.PlayerFootSpeed = 1f;
        data.PlayerBlindLevel = 120;
        data.PlayerBreakConstant = 3;
        data.PlayerMaxBreakProbability = 50;

        data.RobotDownInitStates = new bool[] { true, true, true, true, true, false };

        data.ConveyorSpeed = 1f;
        data.ItemSpanSpace = 2f;
        //data.NeedItemIncrease = 50;

        data.MaxBatteryTime = 40;
        gameObject.SetActive(false);

        main.SelectedDifficulty = true;
    }
}
