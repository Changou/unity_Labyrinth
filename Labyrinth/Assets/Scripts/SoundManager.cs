using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

[System.Serializable]
public class Sound  //������Ʈ �߰� �Ұ���. MonoBehavior ��� �� �޾Ƽ�. �׳� C# Ŭ����.
{
    public string name;     //�� �̸�
    public AudioClip clip;  //��
}

public class SoundManager : MonoBehaviour
{
    #region singleton
    static public SoundManager instance;  // �ڱ� �ڽ��� ���� �ڿ�����. static�� ���� �ٲ� �����ȴ�.

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(gameObject);  // �� �ٲ� �� �ڱ� �ڽ� �ı� ����
        }
        else
            Destroy(this.gameObject);
    }
    #endregion singleton

    public Sound[] effectSounds;  // ȿ���� ����� Ŭ����
    public Sound[] bgmSounds;  // BGM ����� Ŭ����

    public AudioSource audioSourceBGM;  
    public AudioSource[] audioSourceEffects;

    public AudioMixer masterMixer;

    public string[] playSoundName;  // ��� ���� ȿ���� ���� �̸� �迭
    public bool playtutorial;


    // Start is called before the first frame update
    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }


    public void PlaySE(string _name)    //ȿ���� ���
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log("��� ���� AudioSource�� ��� ���Դϴ�.");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }
    public void PlayBGM(string _name)   //BGM���
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourceBGM.clip = bgmSounds[i].clip;
                audioSourceBGM.Play();
                return;
            }
        }
        //if (audioSourceBGM.clip.name.Equals("Ending"))
        //{
        //    masterMixer.SetFloat("BGM", 0);
        //}
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }
    public void StopAllSE() //��� ȿ���� ��� ����
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }
    public void StopSE(string _name)    //Ư�� ȿ���� ��� ����
    {
        bool notSound = true;
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                notSound = false;
                break;
            }
        }
        if (notSound)
        {
            Debug.Log("��� ����" + _name + "���尡 �����ϴ�. ");
        }
    }
    public void StopAllBGM()
    {
        audioSourceBGM.Stop();
    }
    public void PauseBGM()
    {
        audioSourceBGM.Pause();
    }
}
