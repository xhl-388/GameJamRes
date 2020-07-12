using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearController : MonoBehaviour
{
    public static FearController instance { private set; get; }
    private float fear=2;
    private const float maxFear=10;
    private GameObject slider;
    private void Awake()
    {
        instance = this;
        slider = GameObject.FindWithTag("UI").transform.GetChild(2).GetChild(8).gameObject;
    }
    private void Start()
    {
        slider.GetComponent<Slider>().value = fear / 10;
    }
    public void AddFear(float add)
    {
        fear += add;
        if (fear >= maxFear)
        {
            GameController.instance.FailByFear(); 
        }
        slider.GetComponent<Slider>().value = fear / 10;
    }
    public void ReduceFear(float reduce)
    {
        fear = Mathf.Clamp(fear - reduce, 0, fear);
        slider.GetComponent<Slider>().value = fear / 10;
    }
}
