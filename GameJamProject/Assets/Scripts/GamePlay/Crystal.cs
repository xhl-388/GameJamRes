using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : CollectableItem
{
    public override void BeCollected()
    {
        if (ItemController.instance.numberOfHarmer != 0)
        {
            UseInterfaceAudio.instance.PlayOneShot(UseInterfaceAudio.instance.glass);
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                if (ItemController.instance.leftPaper != 0)
                {
                    ItemController.instance.FindPaper();
                }
                else if (ItemController.instance.leftProtect != 0)
                {
                    ItemController.instance.FindProtect();
                }
                else
                {

                }
            }
            else
            {
                if (ItemController.instance.leftProtect != 0)
                {
                    ItemController.instance.FindProtect();
                }
                else if (ItemController.instance.leftPaper != 0)
                {
                    ItemController.instance.FindPaper();
                }
                else
                {

                }
            }
            ItemController.instance.CostHarmer();
            Destroy(transform.parent.gameObject);
        }
        else
        {
            TalkController.instance.ShowText("你或许需要一把锤子来搞定它");
        }
    }
}
