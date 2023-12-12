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
            // �ش� ������Ʈ�� �پ� �ִ� ��ũ��Ʈ�� �����ɴϴ�.
            player = playerObject.GetComponent<Player>();
        }
        // ��� ����: ��ũ��Ʈ�� ���������� ã�������� Ȯ���ϰ�, �̸� ����մϴ�.
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
                Debug.LogError("Player ������Ʈ�� PlayerScript�� �����ϴ�.");
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
