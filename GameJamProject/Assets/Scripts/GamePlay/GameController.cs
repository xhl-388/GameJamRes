using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { private set; get; }
    private Dictionary<int, int> opposite = new Dictionary<int, int>();
    private void Awake()
    {
        instance = this;
        opposite.Add(0, 2);
        opposite.Add(1, 3);
        opposite.Add(2, 0);
        opposite.Add(3, 1);
        opposite.Add(4, 5);
        opposite.Add(5, 4);
    }
    public void FailByFear()
    {

    }
    public void FailByCaught()
    {

    }
    public void Succeed()
    {

    }
    public bool IsNear(int x,int y)
    {
        int value;
        opposite.TryGetValue(x,out value);
        if (y == value)
        {
            return false;
        }
        else return true;
    }
}
