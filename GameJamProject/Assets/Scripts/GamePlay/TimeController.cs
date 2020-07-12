using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance { private set; get; }
    public int realTime { private set; get; }
    private int time=0;
    public int currentCostTime;
    public int leftBeFoundTime;
    [HideInInspector]
    public bool[][] isDayTimeData = new bool[8][];
    [HideInInspector]
    public bool[] isDayTime = new bool[6];
    private void Awake()
    {
        instance = this;
        for(int i = 0; i < 6; i++)
        {
            isDayTime[i] = false;
        }
        InitDayTimeData();
        UpdateDayTime();
    }
    public void CostTime(int x)
    {
        time = (time + x) % 24;
        currentCostTime += x;
        if (currentCostTime >= 3)
        {
            Player.instance.isFound = true;
            leftBeFoundTime = 3;
            TalkController.instance.ShowText("你被盯上了");
        }
        else if(leftBeFoundTime!=0)
        {
            leftBeFoundTime--;
            if (leftBeFoundTime == 0)
            {
                Player.instance.isFound = false;
            }
        }
    }
    public void SyTime()
    {
        realTime = time;
        if (realTime == 0)
        {
            UseInterfaceAudio.instance.PlayOneShot(UseInterfaceAudio.instance.clock);
        }
    }
    private void InitDayTimeData()
    {
        bool[] b = new bool[6];
        b[0] = true;
        b[1] = false;
        b[2] = false;
        b[3] = false;
        b[4] = false;
        b[5] = false;
        isDayTimeData[0] = b;
        bool[] b1 = new bool[6];
        b1[0] = true;
        b1[1] = true;
        b1[2] = false;
        b1[3] = false;
        b1[4] = false;
        b1[5] = false;
        isDayTimeData[1] = b1;
        bool[] b2 = new bool[6];
        b2[0] = false;
        b2[1] = true;
        b2[2] = false;
        b2[3] = false;
        b2[4] = false;
        b2[5] = false;
        isDayTimeData[2] = b2;
        bool[] b3 = new bool[6];
        b3[0] = false;
        b3[1] = true;
        b3[2] = true;
        b3[3] = false;
        b3[4] = false;
        b3[5] = false;
        isDayTimeData[3] = b3;
        bool[] b4 = new bool[6];
        b4[0] =false;
        b4[1] = false;
        b4[2] = true;
        b4[3] = false;
        b4[4] = false;
        b4[5] = false;
        isDayTimeData[4] = b4;
        bool[] b5 = new bool[6];
        b5[0] = false;
        b5[1] = false;
        b5[2] = true;
        b5[3] = true;
        b5[4] = false;
        b5[5] = false;
        isDayTimeData[5] = b5;
        bool[] b6 = new bool[6];
        b6[0] = false;
        b6[1] = false;
        b6[2] = false;
        b6[3] = true;
        b6[4] = false;
        b6[5] = false;
        isDayTimeData[6] = b6;
        bool[] b7 = new bool[6];
        b7[0] = true;
        b7[1] = false;
        b7[2] = false;
        b7[3] = true;
        b7[4] = false;
        b7[5] = false;
        isDayTimeData[7] = b7;
    }
    private void UpdateDayTime()
    {
        for(int i = 0; i < 4; i++)
        {
            isDayTime[i] = isDayTimeData[realTime / 3][i];
        }
    }
}
