using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageFont : MonoBehaviour
{
    float Damage;
    public float speed = 1.0f;
    private float timer = 1.0f;

    public TMP_Text Dmgtxt;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Damagesetting(float Damage)
    {
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
        transform.Translate(Vector3.up * speed * Time.deltaTime);
            Destroy(gameObject , timer);
    }
}
