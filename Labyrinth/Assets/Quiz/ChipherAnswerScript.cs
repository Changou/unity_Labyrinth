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
            Debug.Log("정답입니다.");
            chipherqmanager.correct();
           
        }
        else
        {
            Debug.Log("오답입니다.");
            chipherqmanager.wrong();
            
        }
    }
} 
