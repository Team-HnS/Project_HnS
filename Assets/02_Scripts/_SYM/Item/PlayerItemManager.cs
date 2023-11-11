//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerItemManager : MonoBehaviour
//{
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "Item")
//        {
//            Item itemComponent = collision.gameObject.GetComponent<Item>();
//            if (itemComponent != null)
//            {
//                items = ItemManager.Instance.AddItem(items, itemComponent.itemData);
//            }
//        }
//    }
//}
