using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuanYu : MonoBehaviour
{
    public E_Item e_item;

    public Player player;

    private void LoadResources()
    {
        e_item = Resources.Load<E_Item>("");
        e_item.UseEffect();
    }
    private void Start()
    {
        player.Atk += 10;
        player.Str += 10;
        player.Dex += 10;
    }
    
}
