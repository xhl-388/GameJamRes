using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance { private set; get; }
    public int index { private set; get; }
    private void Awake()
    {
        instance = this;
    }
    public void Act()
    {
        int time = TimeController.instance.realTime;
        if (TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][index] || TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][index])
        {
            Move(Random.Range(5, 7));
        }
        else if (Player.instance.isFound)
        {
            if (TimeController.instance.isDayTime[MapController.instance.currentIndexX])
            {
                if (GameController.instance.IsNear(index, MapController.instance.currentIndexX))
                {
                    Move(index);
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < 6; i++)
                    {
                        if (i != index && i != MapController.instance.currentIndexX && !TimeController.instance.isDayTimeData[time/3][i]&& !TimeController.instance.isDayTimeData[(time / 3+1)%8][i])
                        {
                            Move(i);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        Move(index);
                }
            }
            else
            {
                Move(MapController.instance.currentIndexX);
            }
        }
        else
        {
            bool flag = false;
            for(int i = 0; i < 6; i++)
            {
                if(i!=index&&GameController.instance.IsNear(i,index)&& !TimeController.instance.isDayTimeData[time / 3][i]&& !TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][i])
                {
                    Move(i);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Move(index);
            }
        }
    }
    public void Move(int x)
    {
        index = x;
    }
}
