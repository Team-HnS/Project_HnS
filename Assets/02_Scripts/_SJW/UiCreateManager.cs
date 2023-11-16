        using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiCreateManager : MonoBehaviour
{
    public GameObject DamageFont;


    public static UiCreateManager Instance;

    private void Awake()
    {
        Instance = this;
    }
 

    public void CreateDamageFont(int Damage,GameObject target)
    {
        GameObject dmgfont = Instantiate(DamageFont, target.transform.position,PlayerManager.instance.player.transform.rotation);
        dmgfont.GetComponentInChildren<TMP_Text>().text = Damage.ToString();
    }

    public void CreateDamageFont(int Damage, GameObject target,Color color)
    {
        GameObject dmgfont = Instantiate(DamageFont, target.transform.position, PlayerManager.instance.player.transform.rotation);
        TMP_Text txt = dmgfont.GetComponentInChildren<TMP_Text>();
        txt.color = color;
        txt.text = Damage.ToString();
    }
}
