using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box :CollectableItem
{
    public override void BeCollected()
    {
        UseInterfaceAudio.instance.PlayOneShot(UseInterfaceAudio.instance.openBox);
        int x=Random.Range(0, 11);
        if (x < 8)
        {
            ItemController.instance.FindFood();
        }
        else if (x == 8)
        {
            if (ItemController.instance.leftProtect != 0)
            {
                ItemController.instance.FindProtect();
            }
            else if (ItemController.instance.leftHarmer != 0)
            {
                ItemController.instance.FindHarmer();
            }
            else if (ItemController.instance.leftPaper != 0)
            {
                ItemController.instance.FindPaper();
            }
            else ItemController.instance.FindFood();
        }
        else if (x == 9)
        {
            if (ItemController.instance.leftHarmer != 0)
            {
                ItemController.instance.FindHarmer();
            }
            else if (ItemController.instance.leftProtect != 0)
            {
                ItemController.instance.FindProtect();
            }
            else if (ItemController.instance.leftPaper != 0)
            {
                ItemController.instance.FindPaper();
            }
            else ItemController.instance.FindFood();
        }
        else
        {
            if (ItemController.instance.leftPaper != 0)
            {
                ItemController.instance.FindPaper();
            }
            else if (ItemController.instance.leftHarmer != 0)
            {
                ItemController.instance.FindHarmer();
            }
            else if (ItemController.instance.leftProtect != 0)
            {
                ItemController.instance.FindProtect();
            }
            else ItemController.instance.FindFood();
        }
    }
}
