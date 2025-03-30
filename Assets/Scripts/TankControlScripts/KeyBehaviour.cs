using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] InventoryManager.AllItems _itemType;

  

    public void Interact()
    {
      if (CompareTag("FirstPerson"))
        {
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("FirstPerson"))
        {
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }

}
