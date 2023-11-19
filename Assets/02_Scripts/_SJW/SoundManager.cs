using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;


    AudioClip[] bgms;

    public AudioSource bgmPlayer;
    public AudioSource effectSoundPlayer;
    public AudioSource narSoundPlayer;

    public AudioClip[] BGMS;
    public AudioClip[] EffectiveClip;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartVolumeUp()); //���� ��� Ű��
        bgmPlayer.volume = PlayerPrefs.GetFloat("BgmVol", 0.5f);
        effectSoundPlayer.volume = PlayerPrefs.GetFloat("EffectVol", 0.5f);
        narSoundPlayer.volume = PlayerPrefs.GetFloat("NarVol", 0.5f);

    }

    public void BgmPlay(AudioClip bgm)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = bgm;
        bgmPlayer.Play();
    }

    public void BgmPlay(int bgm)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = BGMS[bgm];
        bgmPlayer.Play();
    }

    public void EffectPlay(AudioClip esm)
    {
        effectSoundPlayer.PlayOneShot(esm);
    }

    public void EffectPlay(int num)
    {
        effectSoundPlayer.PlayOneShot(EffectiveClip[num]);
    }

    public void NarPlay(int num)
    {
        narSoundPlayer.PlayOneShot(EffectiveClip[num]);
    }

    public void NarPlay(AudioClip esm)
    {
        narSoundPlayer.PlayOneShot(esm);
    }


    IEnumerator StartVolumeUp()
    {
        while (bgmPlayer.volume < 0.45f)
        {
            bgmPlayer.volume += 0.1f * Time.deltaTime;

            yield return null;
        }

    }

}
