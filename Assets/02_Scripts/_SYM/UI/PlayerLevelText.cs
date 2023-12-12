using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelText : MonoBehaviour
{
    public TMP_Text PlayerLevText;

    Player player;
    private Player playerScript;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // 해당 오브젝트에 붙어 있는 스크립트를 가져옵니다.
            player = playerObject.GetComponent<Player>();
        }
        // 사용 예시: 스크립트가 성공적으로 찾아졌는지 확인하고, 이를 사용합니다.
        if (player != null)
        {
            PlayerLevText = GameObject.Find("PlayerLevel").GetComponent<TMP_Text>();
        }
        else
        {
            if (PlayerManager.instance.player_s != null)
            { player = PlayerManager.instance.player_s; }
            else
            {
                Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
            }
           
        }
    }

    private void Update()
    {
        if(player != null) 
        {
            PlayerLevText.text = "Lv. " + player.Lv.ToString();
        }
        else
        {
            if (PlayerManager.instance.player_s != null)
            player = PlayerManager.instance.player_s;
        }
      

    }
}
