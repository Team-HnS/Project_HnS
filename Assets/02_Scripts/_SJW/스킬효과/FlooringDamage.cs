using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlooringDamage : SkillCollider
{
    public float tick_time;
    public float tick_cool=0;

    private void OnTriggerStay(Collider other)
    {
        tick_cool += Time.deltaTime;

        if(tick_cool >= tick_time)
        {
            if (other.gameObject.layer == 10)
            {
                HitEffcet(other);
                other.gameObject.GetComponent<Monster>().Damaged(damage);
                Debug.Log(other.name + "스킬히트! " + damage + "의 데미지!");
            }

            tick_cool = 0;

        }

    }
}
