using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField]
    public ItemManager itemManager;
    public List<Slot> inventorySlots;
    public List<Slot> equipmentSlots;
    public List<Slot> consumableSlots;

}   
