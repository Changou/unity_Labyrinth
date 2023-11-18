using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Logo2 : MonoBehaviour
{
    SpriteRenderer logo2;
    public float delay;
    public Image image;
    

    void Start()
    {
        logo2 = GetComponent<SpriteRenderer>();
        
        logo2.DOFade(1, 1).SetDelay(delay).OnStart(() =>    //로고가 나타남
        {
            SoundManager.instance.PlaySE("Logo2");
        }).OnComplete(() => 
        {
            logo2.DOFade(0, 1).SetDelay(2);
            StartCoroutine(FadeCoroutine());
        });
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
    }
}
