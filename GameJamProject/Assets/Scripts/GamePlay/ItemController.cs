using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public static ItemController instance { private set; get; }
    public int numberOfProtect { private set; get; }
    public int numberOfPaper { private set; get; }
    public int numberOfHarmer { private set; get; }
    public int leftProtect { private set; get; }
    public int leftHarmer { private set; get; }
    public int leftPaper { private set; get; }
    private GameObject ui;
    private void Awake()
    {
        instance = this;
        leftProtect = 2;
        leftPaper = 3;
        leftHarmer = Random.Range(0, 4);
        ui = GameObject.FindWithTag("UI").transform.GetChild(2).gameObject;
    }
    public void FindFood()
    {
        FearController.instance.ReduceFear(Random.Range(2, 5));
        TalkController.instance.ShowText("你找到食物，狼吞虎咽");
        Debug.Log("FindFood");
    }
    public void FindProtect()
    {
        TalkController.instance.ShowText("护身符，你相信它能救你一命");
        numberOfProtect++;
        leftProtect--;
        ui.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>().text = numberOfProtect.ToString();
    }
    public void FindHarmer()
    {
        TalkController.instance.ShowText("你找到了锤子，它貌似十分坚硬");
        numberOfHarmer++;
        leftProtect--;
        ui.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Text>().text = numberOfHarmer.ToString();
    }
    public void FindPaper()
    {
        TalkController.instance.ShowText("你找到了一张破旧的纸条");
        numberOfPaper++;
        leftPaper--;
        ui.transform.GetChild(7).GetChild(0).gameObject.GetComponent<Text>().text = numberOfPaper.ToString();
    }
    public void CostHarmer()
    {
        numberOfHarmer--;
        ui.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Text>().text = numberOfHarmer.ToString();
    }
    public void CostProtect()
    {
        numberOfProtect--;
        TalkController.instance.ShowText("你惊恐万分，护身符碎裂了");
        ui.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>().text = numberOfProtect.ToString();
    }
}
