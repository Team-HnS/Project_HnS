using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footstep;
    [SerializeField]
    private float footstepInterval=0.35f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFootstepSound());
    }


    private IEnumerator PlayFootstepSound()
    {
        while (true)
        {
            yield return new WaitUntil(() => PlayerManager.instance.player_s.state == Player.PlayerState.Run);
            // 상태가 Run일 때만 실행
            if (PlayerManager.instance.player_s.state == Player.PlayerState.Run)
            {
                SoundManager.instance.EffectPlay(footstep[Random.Range(0,footstep.Length)]);
            }
            yield return new WaitForSeconds(footstepInterval);
        }
    }

}
