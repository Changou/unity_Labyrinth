using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartText : MonoBehaviour
{
    public Text text;
    public float delay;
    Title title;
    public Image image;
    public GameObject particle;

    public int pause;
    bool flag = true;

    private void Awake()
    {
        text.color = new Color(250,255,131,0);
        particle.gameObject.SetActive(false);
    }

    void Start()
    {
        title = GetComponent<Title>();
        text.DOFade(1, 1).SetDelay(delay).SetLoops(-1, LoopType.Yoyo).OnPlay(()=>
        {
            particle.SetActive(true);
        });
    }

    void Update()
    {
        if (title.LogoAnimePlay && Input.anyKeyDown && flag)    //타이틀이 나오고 아무키나 입력 시
        {
            flag = false;
            SoundManager.instance.PlaySE("Start");
            SoundManager.instance.StopAllBGM();

            text.DOFade(1, 0.5f).SetLoops(3, LoopType.Restart).OnComplete(() =>
            {
                StartCoroutine(FadeCoroutine());
            });
        }
    }

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0f;
        yield return new WaitForSeconds(1f);
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}