using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static E_Item;

public class EquipmentManager : MonoBehaviour
{
    public List<Slot> equipmentSlots; // Inspector에서 할당

    // 장비 슬롯을 초기화합니다.
    private void Awake()
    {
        equipmentSlots = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    // 드랍된 아이템을 처리합니다.
    public void HandleItemDrop(E_Item item)
    {
        Equipment_Type type = item.Type;
        int slotIndex = (int)type; // Equipment_Type enum의 인덱스를 사용

        // 슬롯에 이미 아이템이 있는지 확인
        if (IsSlotOccupied(slotIndex))
        {
            Debug.Log("해당 타입의 아이템이 이미 장비창에 있습니다.");
            return;
        }

        // 아이템을 슬롯에 할당
        Slot slotToEquip = equipmentSlots[slotIndex];
        slotToEquip.AssignItem(item);

        // 플레이어의 스탯에 아이템 능력치 적용
        ApplyItemStatsToPlayer(item);

        // UI 업데이트
        UpdateEquipmentUI();
    }

    // 해당 슬롯에 이미 아이템이 있는지 확인합니다.
    private bool IsSlotOccupied(int index)
    {
        return equipmentSlots[index].itemData != null;
    }

    // 아이템의 능력치를 플레이어에 적용합니다.
    private void ApplyItemStatsToPlayer(E_Item item)
    {
        PlayerManager.instance.player_s.Cur_Hp += item.HpUp;
        PlayerManager.instance.player_s.Cur_Mp += item.MpUp;
        PlayerManager.instance.player_s.Atk += item.AtkUp;
        PlayerManager.instance.player_s.Igt += item.ItgUP;
        PlayerManager.instance.player_s.Def += item.DefUp;
        PlayerManager.instance.player_s.Move_Speed += item.Speed;

        // 나머지 스탯도 마찬가지로 적용
    }

    // 장비창 UI를 업데이트합니다.
    private void UpdateEquipmentUI()
    {
        foreach (var slot in equipmentSlots)
        {
            slot.UpdateSlotUI();
        }
    }
}
