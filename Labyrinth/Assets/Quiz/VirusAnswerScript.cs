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
            Debug.Log("�����Դϴ�.");
            virusqmanager.correct();

        }
        else
        {
            Debug.Log("�����Դϴ�.");
            virusqmanager.wrong();
        }
    }
}
