using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public NetworkQManager networkqmanager;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("정답입니다.");
            networkqmanager.correct();

        }
        else
        {
            Debug.Log("오답입니다.");
            networkqmanager.wrong();

        }
    }
}
