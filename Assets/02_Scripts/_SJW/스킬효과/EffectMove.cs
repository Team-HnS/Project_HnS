using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 5초 동안 앞으로 이동
        if (timer < 5f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
