using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearController : MonoBehaviour
{
    public static FearController instance { private set; get; }
    private float fear=5;
    private const float maxFear=20;
    private void Awake()
    {
        instance = this;
    }
    public void AddFear(float add)
    {
        fear += add;
        if (fear >= maxFear)
        {
            GameController.instance.FailByFear(); 
        }
    }
    public void ReduceFear(float reduce)
    {
        fear = Mathf.Clamp(fear - reduce, 0, fear);
    }
}
