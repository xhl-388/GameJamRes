using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearController : MonoBehaviour
{
    public static FearController instance { private set; get; }
    private float fear=2;
    private const float maxFear=10;
    private GameObject text;
    private void Awake()
    {
        instance = this;
        text = GameObject.FindWithTag("UI").transform.GetChild(2).GetChild(4).GetChild(0).gameObject;
    }
    public void AddFear(float add)
    {
        fear += add;
        if (fear >= maxFear)
        {
            GameController.instance.FailByFear(); 
        }
        text.GetComponent<Text>().text = fear.ToString();
    }
    public void ReduceFear(float reduce)
    {
        fear = Mathf.Clamp(fear - reduce, 0, fear);
        text.GetComponent<Text>().text = fear.ToString();
    }
}
