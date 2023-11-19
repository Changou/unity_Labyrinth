using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public WebQManager webqmanager;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("정답입니다.");
            webqmanager.correct();

        }
        else
        {
            Debug.Log("오답입니다.");
            webqmanager.wrong();

        }
    }
}
