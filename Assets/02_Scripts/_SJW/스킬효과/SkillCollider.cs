using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollider : MonoBehaviour
{
    public Collider range;
    public int damage;

    private void Awake()
    {
        range = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Monster>().Damaged(damage);
            Debug.Log(other.name + "��ų��Ʈ! " + damage + "�� ������!");
        }
    }


    public IEnumerator ColliderOn(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!range.enabled)
        {
            range.enabled = true;
        }

    }

}
