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
        GameObject dmgfont = Instantiate(DamageFont, target.transform.position,Quaternion.identity);
        dmgfont.GetComponentInChildren<TMP_Text>().text = Damage.ToString();

    }
}
