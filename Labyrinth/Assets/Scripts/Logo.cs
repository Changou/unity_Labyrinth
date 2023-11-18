using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    public float speed;
    public float delay;
    public float ToScale;

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(0, 0, 0);
        
        transform.DOScale(ToScale, speed).SetDelay(delay).OnStart(() =>
        {
            SoundManager.instance.PlaySE("Logo1");
        }).SetEase(Ease.OutElastic).OnComplete(()=>
        {
            sr.DOFade(0, 1).SetDelay(3).OnComplete(() =>
            {
                SceneManager.LoadScene(1);
            });
        });
        
        
    }

}
