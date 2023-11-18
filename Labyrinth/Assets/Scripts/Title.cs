using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;

public class Title : MonoBehaviour
{
    public Text TestText;

    private string typingText;
    private char cursor_char = '|';
    public bool LogoAnimePlay = false;
    SoundManager _theSoundTitle;

    void Start()
    {
        _theSoundTitle = SoundManager.instance;
        _theSoundTitle.PlayBGM("Title");
        StartCoroutine(TypingCoroutine("L A B Y R I N T H "));
    } 

    public IEnumerator TypingCoroutine(string str)
    {

        //=======================================================================================================
        // Blink cursor 
        //=======================================================================================================
        typingText = "";
        for (int waitCount = 0; waitCount < 3; waitCount++)
        {
            TestText.text = typingText + cursor_char;
            yield return new WaitForSeconds(0.25f);
            TestText.text = typingText;
            yield return new WaitForSeconds(0.25f);
        }
        _theSoundTitle.PlaySE("Title");
        //=======================================================================================================
        // Typing effect 
        //=======================================================================================================
        int strLength = str.GetTypingLength();
        for (int i = 0; i <= strLength; i++)
        {
            typingText = str.Typing(i);
            TestText.text = typingText + cursor_char;
            yield return new WaitForSeconds(0.1f);

            if(i == 10){
                _theSoundTitle.StopAllSE();
                for (int waitCount = 0; waitCount < 3; waitCount++)
                {
                    TestText.text = typingText + cursor_char;
                    yield return new WaitForSeconds(0.25f);
                    TestText.text = typingText;
                    yield return new WaitForSeconds(0.25f);
                }
                _theSoundTitle.PlaySE("Title");
            }
        }
        _theSoundTitle.StopAllSE();
        //=======================================================================================================
        // Blink cursor | Ä¿¼­ ±ôºýÀÓ
        //=======================================================================================================
        for (int waitCount = 0; waitCount < 3; waitCount++)
        {
            TestText.text = typingText + cursor_char;
            yield return new WaitForSeconds(0.25f);
            TestText.text = typingText;
            yield return new WaitForSeconds(0.25f);
        }
        LogoAnimePlay = true;
    }
}
