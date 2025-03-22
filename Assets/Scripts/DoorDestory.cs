using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorDestory : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _requiredItem;

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._InventoryItems.Contains(itemRequired))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (HasRequiredItem(_requiredItem))
        {
            Destroy(gameObject);
        }
    }
}
