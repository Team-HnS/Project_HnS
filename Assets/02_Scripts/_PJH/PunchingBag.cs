using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    private Outline outline;

    public int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    private void Awake()
    {        
        outline = GetComponent<Outline>();
    }

    private void OnMouseOver()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void Damaged(int Damage) // 데미지 받는 함수
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject);
    }

    public void Damaged(int Damage, Color color) // 데미지 받는 함수 색칠놀이
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject, color);
    }
}
