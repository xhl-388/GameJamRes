using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController instance { private set; get; }
    public int numberOfProtect { private set; get; }
    public int numberOfPaper { private set; get; }
    public int numberOfHarmer { private set; get; }
    public int leftProtect { private set; get; }
    public int leftHarmer { private set; get; }
    public int leftPaper { private set; get; }
    private void Awake()
    {
        instance = this;
        leftProtect = 2;
        leftPaper = 3;
        leftHarmer = Random.Range(0, 4);
    }
    public void FindFood()
    {
        FearController.instance.ReduceFear(Random.Range(2, 5));
    }
    public void FindProtect()
    {
        numberOfProtect++;
        leftProtect--;
    }
    public void FindHarmer()
    {
        numberOfHarmer++;
        leftProtect--;
    }
    public void FindPaper()
    {
        numberOfPaper++;
        leftPaper--;
    }
    public void CostHarmer()
    {
        numberOfHarmer--;
    }
}
