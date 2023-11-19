using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipherAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public ChipherQManager chipherqmanager;
    

   public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("�����Դϴ�.");
            chipherqmanager.correct();
           
        }
        else
        {
            Debug.Log("�����Դϴ�.");
            chipherqmanager.wrong();
            
        }
    }
} 
