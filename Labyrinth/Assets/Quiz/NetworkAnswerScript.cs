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
            Debug.Log("�����Դϴ�.");
            networkqmanager.correct();

        }
        else
        {
            Debug.Log("�����Դϴ�.");
            networkqmanager.wrong();

        }
    }
}
