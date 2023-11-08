//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject go_InventoryBase; // Inventory_Base 이미지
//    [SerializeField]
//    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 

//    private Slot[] slots;  // 슬롯들 배열

//    void Start()
//    {
//        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
//    }



//    private void OpenInventory()
//    {
//        go_InventoryBase.SetActive(true);
//    }

//    private void CloseInventory()
//    {
//        go_InventoryBase.SetActive(false);
//    }

//    public void AcquireItem(ItemData _item, int _count = 1)
//    {
//        if (C_Item.ItemType.Equipment != _item.Item_Icon)
//        {
//            for (int i = 0; i < slots.Length; i++)
//            {
//                if (slots[i].C_item != null)  // null 이라면 slots[i].item.itemName 할 때 런타임 에러 나서
//                {
//                    if (slots[i].C_item.ItemName == _item.ItemName)
//                    {
//                        slots[i].SetSlotCount(_count);
//                        return;
//                    }
//                }
//            }
//        }

//        for (int i = 0; i < slots.Length; i++)
//        {
//            if (slots[i].item == null)
//            {
//                slots[i].AddItem(_item, _count);
//                return;
//            }
//        }
//    }
//}
