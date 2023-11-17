using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPannel : MonoBehaviour
{
    public Slider bgmslider;
    public Slider effectSlider;
    public Slider narSlider;

    private void OnEnable()
    {
        SoundManager.instance.EffectPlay(2);
        //SoundManager.instance.NarPlay(11);
        //Data_Manager.instance.isPause = true;
        //Time.timeScale = 0;
        bgmslider.value = SoundManager.instance.bgmPlayer.volume;
        effectSlider.value = SoundManager.instance.effectSoundPlayer.volume;
        narSlider.value = SoundManager.instance.narSoundPlayer.volume;
    }

    private void OnDisable()
    {
        SoundManager.instance.EffectPlay(1);
        //Data_Manager.instance.isPause = false;
        //Time.timeScale = 1;
    }


    public void BgmVolChanger()
    {
        SoundManager.instance.bgmPlayer.volume = bgmslider.value;
    }
    public void EffectVolChanger()
    {
        SoundManager.instance.effectSoundPlayer.volume = effectSlider.value;
    }
    public void NarVolChanger()
    {
        SoundManager.instance.narSoundPlayer.volume = narSlider.value;
    }

}
