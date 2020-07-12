using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { private set; get; }
    private Dictionary<int, int> opposite = new Dictionary<int, int>();

    public int placeIndex { private set; get; }
    public int time { private set; get; }
    public int way { private set; get; }

    private LayerMask collectableLayer;
    private void Awake()
    {
        instance = this;
        opposite.Add(0, 2);
        opposite.Add(1, 3);
        opposite.Add(2, 0);
        opposite.Add(3, 1);
        opposite.Add(4, 5);
        opposite.Add(5, 4);
        placeIndex = Random.Range(0, 6);
        time = Random.Range(0, 8);
        way = Random.Range(0, 2);
        collectableLayer = 1 << LayerMask.NameToLayer("Collectable");
    }
    private void Start()
    {
        if (way == 0)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(MapController.instance.bigMap[placeIndex].transform.position, new Vector2(40, 40), 0, collectableLayer);
            List<GameObject> obj = new List<GameObject>();
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].CompareTag("Box"))
                {
                    obj.Add(colliders[i].gameObject);
                }
            }
            obj[Random.Range(0, obj.Count)].tag = "Success";
        }
    }
    public void FailByFear()
    {
        TalkController.instance.ShowText("你恐惧着咆哮，腐烂了");
        StartCoroutine(Failed());
    }
    public void FailByCaught()
    {
        TalkController.instance.ShowText("你被抓住了，成为了食物");
        StartCoroutine(Failed());
    }
    public void Succeed()
    {
        if (way == 0)
        {
            TalkController.instance.ShowText("箱子里发出了光，你钻了进去");
        }
        else
        {
            TalkController.instance.ShowText("你安心地睡了，逃离了黑暗");
        }
        StartCoroutine(Win());
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
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
    IEnumerator Failed()
    {
        yield return new WaitForSeconds(0.5f);
        Player.instance.UI_GameOver.SetActive(true);
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);
        Player.instance.UI_Succeed.SetActive(true);
    }
}
