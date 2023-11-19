using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOptionPannel : MonoBehaviour
{
    public Slider bgmslider;
    public Slider effectSlider;
    public Slider narSlider;
    public AudioSource bgms;
    public AudioClip[] sounds;


    private void OnEnable()
    {
        //bgms.PlayOneShot(sounds[0]);

        bgmslider.value = PlayerPrefs.GetFloat("BgmVol", 0.5f);
        effectSlider.value = PlayerPrefs.GetFloat("EffectVol", 0.5f);
        narSlider.value = PlayerPrefs.GetFloat("NarVol", 0.5f);
    }

    private void OnDisable()
    {
        //bgms.PlayOneShot(sounds[1]);

    }


    public void BgmVolChanger()
    {
        bgms.volume = bgmslider.value;
        PlayerPrefs.SetFloat("BgmVol", bgmslider.value);
    }
    public void EffectVolChanger()
    {
        PlayerPrefs.SetFloat("EffectVol", effectSlider.value);
    }
    public void NarVolChanger()
    {
        PlayerPrefs.SetFloat("NarVol", narSlider.value);
    }

}
