using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Mode
    {
        search,
        move,
        none
    }
    public static Player instance { private set; get; }
    private Mode mode=Mode.none;
    private LayerMask collectableLayer;
    private LayerMask moveableLayer;
    private GameObject UI_Gameplay;
    private GameObject UI_Choose;
    public bool isFound;
    private void Awake()
    {
        instance = this;
        collectableLayer =1<< LayerMask.NameToLayer("Collectable");
        moveableLayer = 1 << LayerMask.NameToLayer("Moveable");
        GameObject ui = GameObject.FindWithTag("UI");
        UI_Gameplay = ui.transform.GetChild(0).gameObject;
        UI_Choose = ui.transform.GetChild(1).gameObject;
        UI_Choose.SetActive(false);
    }
    private void Update()
    {
        if (mode == Mode.search)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, collectableLayer);
                if (collider)
                {
                    if (ItemController.instance.numberOfPaper==3&& collider.CompareTag("Success"))
                    {
                        if (TimeController.instance.realTime >= GameController.instance.time * 3 && TimeController.instance.realTime < GameController.instance.time * 3 + 3)
                        {
                            GameController.instance.Succeed();
                        }
                    }
                    collider.GetComponent<CollectableItem>().BeCollected();
                    TimeController.instance.CostTime(1);
                    FearController.instance.AddFear(2);
                    UI_Choose.SetActive(false);
                    UI_Gameplay.SetActive(true);
                    mode = Mode.none;
                    Enemy.instance.Act();
                    TimeController.instance.SyTime();
                }
            }
        }
        else if (mode == Mode.move)
        {
            if (Input.GetMouseButton(0)) {
                Collider2D collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, moveableLayer);
                if (collider)
                {
                    TalkController.instance.ShowText("你面向" + GetDir(collider.transform.position - MapController.instance.maps[MapController.instance.currentIndexX][MapController.instance.currentIndexY].transform.position) + "，穿过正对着的门");
                    Door door = collider.GetComponent<Door>();
                    MapController.instance.ChangeRoom(door.indexX, door.indexY);
                    TimeController.instance.CostTime(1);
                    FearController.instance.AddFear(1);
                    mode = Mode.none;
                    UI_Choose.SetActive(false);
                    UI_Gameplay.SetActive(true);
                    Enemy.instance.Act();
                    TimeController.instance.SyTime();
                }
            }
        }
    }
    public void Search()
    {
        UI_Choose.SetActive(true);
        UI_Gameplay.SetActive(false);
        mode = Mode.search;
    }
    public void Move()
    {
        UI_Choose.SetActive(true);
        UI_Gameplay.SetActive(false);
        mode = Mode.move;

    }
    public void Back()
    {
        UI_Choose.SetActive(false);
        UI_Gameplay.SetActive(true);
        mode = Mode.none;
        TalkController.instance.ShowText("犹豫，空洞的灵魂");
    }
    public void Rest()
    {
        TalkController.instance.ShowText("你睡了一觉，忘记了恐惧");
        if (ItemController.instance.numberOfPaper == 3)
        {
            if (GameController.instance.placeIndex == MapController.instance.currentIndexX && TimeController.instance.realTime < GameController.instance.time*3+3&&TimeController.instance.realTime>=GameController.instance.time*3&&GameController.instance.way==1)
            {
                GameController.instance.Succeed();
            }
        }
        FearController.instance.ReduceFear(2);
        TimeController.instance.CostTime(1);
        Enemy.instance.Act();
        TimeController.instance.SyTime();
    }
    private string GetDir(Vector2 vec)
    {
        if (Mathf.Abs(vec.x) < 0.1)
        {
            if (vec.y > 0)
            {
                return "上方";
            }
            else return "下方";
        }
        else
        {
            if (vec.x > 0)
            {
                return "右侧";
            }
            else return "左侧";
        }
    }
}
