using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public VirusQManager virusqmanager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("정답입니다.");
            virusqmanager.correct();

        }
        else
        {
            Debug.Log("오답입니다.");
            virusqmanager.wrong();
        }
    }
}
