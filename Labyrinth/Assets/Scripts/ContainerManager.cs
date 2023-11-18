using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerManager : MonoBehaviour
{
    //ü��
    public int maxHp;
    public int currentHp;

    //Ű_������
    public int maxKey;
    public int currentKey;

    public Sprite changehp_img;
    public Sprite heart_img;

    public Sprite changeKey_img;
    public Sprite key_img;

    [SerializeField] Image[] hpImage = null;
    [SerializeField] Image[] keyImage = null;

    public void PlusKey(int p_num)      //Ű ����
    {
        currentKey += p_num;
        SettingKEYImage();
    }

    public void DecreaseHp(int p_num)      //ü�� ����
    {
        currentHp -= p_num;
        SettingHPImage();
    }

    void SettingKEYImage()      //Ű ���� ����
    {
        for (int i = 0; i < keyImage.Length; i++)
        {
            keyImage[i].gameObject.SetActive(true);
            if (i < currentKey)
                keyImage[i].sprite = key_img;
            else
                keyImage[i].sprite = changeKey_img;
        }
    }

    void SettingHPImage()
    {
        for(int i = 0; i < hpImage.Length; i++)
        {
            hpImage[i].gameObject.SetActive(true);
            if (i < currentHp)
                hpImage[i].sprite = heart_img;
            else
                hpImage[i].sprite = changehp_img;
        }
    }
    public void Visivle()   //�������̽� Ȱ��ȭ
    {
        SettingHPImage();
        SettingKEYImage();
    }
    public void Envisivle() //�������̽� ��Ȱ��ȭ
    {
        for(int i = 0; i < hpImage.Length; i++)
        {
            hpImage[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < keyImage.Length; i++)
        {
            keyImage[i].gameObject.SetActive(false);
        }
    }
}
