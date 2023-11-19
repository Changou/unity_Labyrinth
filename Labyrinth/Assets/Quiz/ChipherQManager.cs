using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipherQManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    public GameObject correctPanel;
    public GameObject wrongPanel;
    public Text correctPanelText;
    public Text wrongPanelText;
    public GameObject endQuiz;      //추가
    public GameObject wrongQuiz;       //추가
    public QuizManger qm;               //추가

    private void Start()
    {
        correctPanel.SetActive(false);
        wrongPanel.SetActive(false);
        generateQuestion();
    }

    public void correct()
    {
        correctPanelText.text = QnA[currentQuestion].CorrectAnswerDescription;
        correctPanel.SetActive(true);
        QnA.RemoveAt(currentQuestion);
        Invoke("DeactivateCorrectPanel", 5f);
    }

    public void wrong()
    {
        wrongPanelText.text = QnA[currentQuestion].WrongAnswerDescription;
        wrongPanel.SetActive(true);
        QnA.RemoveAt(currentQuestion);
        wrongQuiz.SetActive(true);      //추가
        Invoke("DeactivateWrongPanel", 5f);
    }

    private void DeactivateCorrectPanel()
    {
        correctPanel.SetActive(false);
        generateQuestion(); 
    }

    private void DeactivateWrongPanel()
    {
        wrongPanel.SetActive(false);
        generateQuestion(); 
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<ChipherAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<ChipherAnswerScript>().isCorrect = true; 
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("문제 풀이 완료");
            endQuiz.SetActive(true);        //추가
            qm.QuizIncrement();             //추가
        }
        
    }
}
