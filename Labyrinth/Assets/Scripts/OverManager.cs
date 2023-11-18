using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OverManager : MonoBehaviour
{
    public Image OverBG;
    public Image Fade;
    public Text OverText;
    public GameObject ReBtn;
    public GameObject ExBtn;
    ContainerManager hpControl;
    PlayerAction player;

    void Awake()
    {
        hpControl = FindObjectOfType<ContainerManager>();
        player = FindObjectOfType<PlayerAction>();
    }

    void Start()
    {
        Fade.color = new Color(0, 0, 0, 0);
        Fade.gameObject.SetActive(false);
        OverBG.color = new Color(0, 0, 0, 0);
        OverText.color = new Color(1, 1, 1, 0);
        ReBtn.SetActive(false);
        ExBtn.SetActive(false);
    }

    public void ExitGame()
    {
        SoundManager.instance.PlaySE("Start");
        StartCoroutine(GameExit());
    }
    IEnumerator GameExit()
    {
        yield return new WaitForSeconds(1f);
        Fade.gameObject.SetActive(true);
        float fadeCount = 0f;

        yield return new WaitForSeconds(1f);
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }
        Exit();
    }

    public void Exit()
    {
#if UNITY_EDITOR    //����� ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //�̰͸� ���� ��
#endif
    }

    public void Restart()   //�����
    {
        SoundManager.instance.PlaySE("Start");
        StartCoroutine(FadeCoroutineIn());
        hpControl.currentHp = 3;
        player.PositionReset();
        player.gameObject.layer = 10;
        player.yourDied = false;
        player.flag = false;
    }
    public void GameOverView()
    {
        StartCoroutine(GameOverViewStart());
    }

    IEnumerator GameOverViewStart()     //���ӿ��� �� ����
    {
        yield return new WaitForSeconds(2f);
        OverBG.color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(2f);
        OverText.DOFade(1, 1f);
        yield return new WaitForSeconds(2f);
        ReBtn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ExBtn.SetActive(true);
    }

    IEnumerator FadeCoroutineIn()       //ȭ����ȯ ���̵� �����
    {
        Fade.gameObject.SetActive(true);
        float fadeCount = 0f;
        
        yield return new WaitForSeconds(1f);
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(1f);
        ReBtn.SetActive(false);
        ExBtn.SetActive(false);
        OverText.color = new Color(1, 1, 1, 0);
        OverBG.color = new Color(1, 1, 1, 0);
        player.WakeUp();
        yield return new WaitForSeconds(0.5f);
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, fadeCount);
        }
        hpControl.Visivle();
        Fade.gameObject.SetActive(false);
        SoundManager.instance.PlayBGM("Main");
        player.RigidConsFree();
    }
}
