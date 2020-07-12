using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    public static TalkController instance { private set; get; }
    private List<Text> texts = new List<Text>();
    private void Awake()
    {
        instance = this;
        for(int i = 0; i < 4; i++)
        {
            texts.Add(transform.GetChild(i).gameObject.GetComponent<Text>());
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void ShowText(string str)
    {
        if (texts.Count != 0)
        {
            Text t = texts[0];
            t.gameObject.SetActive(true);
            t.text = str;
            texts.Remove(t);
            StartCoroutine(Fade(t));
        }
    }
    IEnumerator Fade(Text text)
    {
        for (int i = 0; i < 2 / Time.deltaTime; i++) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a-Time.deltaTime*0.5f);
            yield return new WaitForFixedUpdate();
        }
        texts.Add(text);
        text.gameObject.SetActive(false);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
}
