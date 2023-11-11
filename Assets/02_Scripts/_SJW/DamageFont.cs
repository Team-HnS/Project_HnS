using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DamageFont : MonoBehaviour
{
    float Damage;
    public float speed = 1.0f;
    private float timer = 3.0f;
    public TMP_Text Dmgtxt;
    Sequence damageseqence;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        damageseqence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + Random.Range(0.5f, 2f), 1.5f).SetEase(Ease.OutBack))
            .Join(transform.DOMoveX(transform.position.x + Random.Range(-3f, 3f), 1.5f))
            .Join(transform.DOScale(0.7f, 0.25f))
            .Join(Dmgtxt.DOFade(0,3f));
    }
    public void Damagesetting(float Damage)
    {
        Dmgtxt.text = ((int)Damage).ToString();
    }

    public void Critical_Damagesetting(float Damage)
    {
        Dmgtxt.color = Color.red;
        Dmgtxt.text = ((int)Damage).ToString();
    }


    public void Goldsetting(float result)
    {
        Dmgtxt.color = Color.yellow;
        Dmgtxt.text = "+" + ((int)result).ToString() + " G";
    }

    public void Emeraldsetting(float result)
    {
        Dmgtxt.color = Color.green;
        Dmgtxt.text = "+" + ((int)result).ToString() + " E";
    }


    // Update is called once per frame
    void Update()
    {
      

        //transform.Translate(Vector3.up * speed * Time.deltaTime);
            Destroy(gameObject , timer);
    }
}
