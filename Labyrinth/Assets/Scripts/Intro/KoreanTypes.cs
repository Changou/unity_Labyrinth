using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
using UnityEngine.Events;


public class KoreanTypes : MonoBehaviour
{
    [TextArea]
    public string msg;
    public float delay = 1f;
    public UnityEvent onComplete;

    Text mText;
    WaitForSeconds typingWait;
    WaitForSeconds eventWait;
    SoundManager thesound;

    void Awake()
    {
        mText = GetComponent<Text>();
        thesound = FindObjectOfType<SoundManager>();
        msg = mText.text;
        typingWait = new WaitForSeconds(0.03f);
        eventWait = new WaitForSeconds(1f);
    }

    public void StartTyping(string value)
    {
        msg = value;
        StartCoroutine(TypingMsg());
    }

    IEnumerator TypingMsg()
    {
        int typingLength = msg.GetTypingLength();
        mText.text = "";
        thesound.PlaySE("Talk");
        for (int index = 0; index <= typingLength; index++)
        {
            yield return typingWait;
            mText.text = msg.Typing(index);
        }
        thesound.StopSE("Talk");
        yield return eventWait;
        onComplete.Invoke();
    }
}
