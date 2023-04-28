using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class İnventoryİtemController : MonoBehaviour
{
    İtem item;

    public Button RemoveButton;

    public void RemoveItem()
    {
        İnventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(İtem newİtem)
    {
        item = newİtem;
    }
}
