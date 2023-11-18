using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static E_Item;

public class EquipmentManager : MonoBehaviour
{
    public List<Slot> equipmentSlots; // Inspector���� �Ҵ�

    // ��� ������ �ʱ�ȭ�մϴ�.
    private void Awake()
    {
        equipmentSlots = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    // ����� �������� ó���մϴ�.
    public void HandleItemDrop(E_Item item)
    {
        Equipment_Type type = item.Type;
        int slotIndex = (int)type; // Equipment_Type enum�� �ε����� ���

        // ���Կ� �̹� �������� �ִ��� Ȯ��
        if (IsSlotOccupied(slotIndex))
        {
            Debug.Log("�ش� Ÿ���� �������� �̹� ���â�� �ֽ��ϴ�.");
            return;
        }

        // �������� ���Կ� �Ҵ�
        Slot slotToEquip = equipmentSlots[slotIndex];
        slotToEquip.AssignItem(item);

        // �÷��̾��� ���ȿ� ������ �ɷ�ġ ����
        ApplyItemStatsToPlayer(item);

        // UI ������Ʈ
        UpdateEquipmentUI();
    }

    // �ش� ���Կ� �̹� �������� �ִ��� Ȯ���մϴ�.
    private bool IsSlotOccupied(int index)
    {
        return equipmentSlots[index].itemData != null;
    }

    // �������� �ɷ�ġ�� �÷��̾ �����մϴ�.
    private void ApplyItemStatsToPlayer(E_Item item)
    {
        PlayerManager.instance.player_s.Cur_Hp += item.HpUp;
        PlayerManager.instance.player_s.Cur_Mp += item.MpUp;
        PlayerManager.instance.player_s.Atk += item.AtkUp;
        PlayerManager.instance.player_s.Igt += item.ItgUP;
        PlayerManager.instance.player_s.Def += item.DefUp;
        PlayerManager.instance.player_s.Move_Speed += item.Speed;

        // ������ ���ȵ� ���������� ����
    }

    // ���â UI�� ������Ʈ�մϴ�.
    private void UpdateEquipmentUI()
    {
        foreach (var slot in equipmentSlots)
        {
            slot.UpdateSlotUI();
        }
    }
}
