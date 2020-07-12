using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance { private set; get; }
    public int index { private set; get; }
    private int indexDir;
    private bool cantMove = false;
    private void Awake()
    {
        instance = this;
        index = 5;
        indexDir = 1;
    }
    public void Act()
    {
        if (cantMove)
        {
            cantMove = false;
            return;
        }
        int time = TimeController.instance.realTime;
        if (TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][index] || TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][index])
        {
            Move(Random.Range(4, 6));
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
                    List<int> list = new List<int>();
                    for (int i = 0; i < 6; i++)
                    {
                        if (i != index && i != MapController.instance.currentIndexX && !TimeController.instance.isDayTimeData[time/3][i]&& !TimeController.instance.isDayTimeData[(time / 3+1)%8][i])
                        {
                            list.Add(i);
                        }
                    }
                    if (list.Count != 0)
                    {
                        Move(list[Random.Range(0, list.Count)]);
                    }
                }
            }
            else
            {
                Move(MapController.instance.currentIndexX);
            }
        }
        else
        {
            List<int> list = new List<int>();
            for(int i = 0; i < 6; i++)
            {
                if(i!=index&&GameController.instance.IsNear(i,index)&& !TimeController.instance.isDayTimeData[time / 3][i]&& !TimeController.instance.isDayTimeData[(time / 3 + 1) % 8][i])
                {
                    list.Add(i);
                }
            }
            if (list.Count != 0)
            {
                Move(list[Random.Range(0, list.Count)]);
            }
        }
        if (index == MapController.instance.currentIndexX)
        {
            if (indexDir == MapController.instance.currentIndexY)
            {
                if (ItemController.instance.numberOfProtect > 0)
                {
                    ItemController.instance.CostProtect();
                    List<int> list = new List<int>();
                    for (int i = 0; i < 6; i++)
                    {
                        if (i != index && GameController.instance.IsNear(i, index))
                        {
                            list.Add(i);
                        }
                    }
                    MapController.instance.ChangeRoom(list[Random.Range(0, list.Count)], Random.Range(0, 4));
                    cantMove = true;
                }
                else
                {
                    GameController.instance.FailByCaught();
                }
            }
            else
            {
                TalkController.instance.ShowText("他要来了，快跑！");
            }
        }
    }
    public void Move(int x)
    {
        index = x;
        indexDir = Random.Range(0, 4);
    }
}
