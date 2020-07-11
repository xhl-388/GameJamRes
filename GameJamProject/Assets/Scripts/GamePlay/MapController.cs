using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapController : MonoBehaviour
{
    public static MapController instance { private set; get; }
    public GameObject[][] maps = new GameObject[6][];
    public int currentIndexX { private set; get; }
    public int currentIndexY { private set; get; }
    private void Awake()
    {
        instance = this;
        currentIndexX = currentIndexY = 0;
        GameObject[] obj=GameObject.FindGameObjectsWithTag("Room").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        for(int i = 0; i < obj.Length; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                maps[i][j] = obj[i].transform.GetChild(j).gameObject;
            }
        }
    }
    public void ChangeRoom(int indexX,int indexY)
    {
        currentIndexX = indexX;
        currentIndexY = indexY;
        Camera.main.transform.position = maps[currentIndexX][currentIndexY].transform.position;
    }
}
