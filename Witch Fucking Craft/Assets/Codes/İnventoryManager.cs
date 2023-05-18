using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class İnventoryManager : MonoBehaviour
{
    public static İnventoryManager Instance;
    public List<İtem> İtems = new List<İtem> ();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle EnableRemove;

    public İnventoryİtemController[] InventoryItems;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Add(İtem item)
    {
        İtems.Add (item);
    }

    public void Remove(İtem item)
    {
        İtems.Remove (item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy (item.gameObject);
        }
        foreach(var item in İtems)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            
            var itemIcon = obj.transform.Find("itemImage").GetComponent<Image>();
            var itemNaame = obj.transform.Find("itemName").GetComponent<Text>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();   
            
            itemNaame.text = item.itemName;
            itemIcon.sprite= item.icon;

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive (true);
            }
        }

        SetInventoryItem();
    }
    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItem()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<İnventoryİtemController>();

        for (int i = 0; i < İtems.Count; i++)
        {
            InventoryItems[i].AddItem(İtems[i]);
        }
    }

}
