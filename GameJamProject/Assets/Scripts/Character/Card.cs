using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card :CollectableItem
{
    public override void BeCollected()
    {
        UseInterfaceAudio.instance.PlayOneShot(UseInterfaceAudio.instance.card);
        if (TimeController.instance.isDayTime[MapController.instance.currentIndexX])
        {
            TalkController.instance.ShowText("太阳保佑着你");
        }
        else
        {
            TalkController.instance.ShowText("黑暗笼罩着你");
        }
    }
}
