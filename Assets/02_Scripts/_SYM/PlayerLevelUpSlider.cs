using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUpSlider : MonoBehaviour
{
    public Slider slider;
    public Image image;

    private void Update()
    {
        if (slider.value == 1)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
