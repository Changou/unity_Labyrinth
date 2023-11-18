using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public InputField passwordInput;
    public Button passwordBtn;
    public Text resultText;
    public GameObject text;

    public bool istrue;

    private string pwOrigin;
    void Awake()
    {
        pwOrigin = "12345";
        istrue = false;
    }

    // Update is called once per frame
    public void ClickBtn()
    {
        passwordBtn.gameObject.SetActive(false);
        passwordInput.gameObject.SetActive(false);
        text.SetActive(false);
        resultText.gameObject.SetActive(true);
        if (passwordInput.text.Equals(pwOrigin))
        {
            resultText.text = "잠금이 해제되었습니다.";
            istrue = true;
        }
        else
        {
            resultText.text = "비밀번호가 맞지 않습니다.";
            istrue = false;
        }
    }
}
