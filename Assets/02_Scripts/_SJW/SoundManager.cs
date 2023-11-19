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
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartVolumeUp()); //시작 브금 키기
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
