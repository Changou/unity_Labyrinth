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
            Debug.Log("�����Դϴ�.");
            webqmanager.correct();

        }
        else
        {
            Debug.Log("�����Դϴ�.");
            webqmanager.wrong();

        }
    }
}
