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
        TalkController.instance.ShowText("你找到了一张破旧的纸条,写着：");
        if (numberOfPaper == 0)
        {
            TalkController.instance.ShowText("时间：" + (3 * GameController.instance.time).ToString() + "到" + (3 * GameController.instance.time + 3).ToString());
        }else if (numberOfPaper == 1)
        {
            TalkController.instance.ShowText("地点：" + GetPlace(GameController.instance.placeIndex));
        }
        else
        {
            string str;
            if (GameController.instance.way == 0)
            {
                str = "在箱子中寻找出口";
            }
            else
            {
                str = "睡去吧";
            }
            TalkController.instance.ShowText("方法：" + str);
        }
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
    private string GetPlace(int x)
    {
        string str;
        switch (x)
        {
            case 0:str = "月亮";
                break;
            case 1:str = "恶魔";
                break;
            case 2:str = "恋人";
                break;
            case 3:
                str = "力量";
                break;
            case 4:
                str = "审判";
                break;
            case 5:
                str = "命运之轮";
                break;
            default:str = "";
                break;
        }
        return str;
    }
}
