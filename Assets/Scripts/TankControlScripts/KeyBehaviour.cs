using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] InventoryManager.AllItems _itemType;

  

    public void Interact()
    {
        Debug.Log("fff");
        InventoryManager.Instance.AddItem(_itemType);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }

}
