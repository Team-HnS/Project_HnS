using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSkillCollider : SkillCollider
{
    public GameObject target;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if(other.gameObject == target)
            {
                other.gameObject.GetComponent<Monster>().hp -= damage;
                Debug.Log(other.name + "��ų��Ʈ! " + damage + "�� ������!");
            }
            else
            {
                other.gameObject.GetComponent<Monster>().hp -= damage/10;
                Debug.Log(other.name + "��ų��Ʈ! " + damage + "�� ������!");
            }

        }
    }




}
