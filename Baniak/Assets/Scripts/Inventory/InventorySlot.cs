
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    InventoryItem item;
    public bool slotTaken;

    void Update()
    {
        SlotTaken();
    }

    public void AddItem(InventoryItem newItem)
    {
        item = newItem;
        icon.sprite=item.icon;
        icon.enabled = true;
        slotTaken = true;
    }

    public void SlotTaken()
    {
       if (!slotTaken)
        {
            icon.enabled = false;
        }
    }

}
