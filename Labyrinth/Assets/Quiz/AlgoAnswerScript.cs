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
            Debug.Log("�����Դϴ�.");
            algoqmanager.correct();

        }
        else
        {
            Debug.Log("�����Դϴ�.");
            algoqmanager.wrong();

        }
    }
}
