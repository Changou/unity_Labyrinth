using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public AlgoQManager algoqmanager;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("정답입니다.");
            algoqmanager.correct();

        }
        else
        {
            Debug.Log("오답입니다.");
            algoqmanager.wrong();

        }
    }
}
