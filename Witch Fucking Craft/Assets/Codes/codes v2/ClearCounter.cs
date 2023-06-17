using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Assertions;

public class ClearCounter : MonoBehaviour,  IKitchenObjectParent
{
   
    [SerializeField] private ObejctsForCounterTops kitchenObjectSO;
   [SerializeField] private Transform counterTopPoint;
   [SerializeField] private ClearCounter secondClearCounter;
   [SerializeField] private bool testing;

   
    private KitchenObje kithcenObject;
    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.Q))
        {
            if(kithcenObject != null)
            {
                kithcenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }
    public void Interact(PlayerV2 player)
    {
        if (kithcenObject == null)
        {
            Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            KitchenObjectTransform.GetComponent<KitchenObje>().SetKitchenObjectParent(this);
            
        }
        else
        {
            //objeyi oyuncuya verelimm
            kithcenObject.SetKitchenObjectParent(player);
        }
        
        
    }
  public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObject(KitchenObje kitchenObject)
    {
        this.kithcenObject = kitchenObject;
    }
    public KitchenObje GetKitchenObject()
    {
        return kithcenObject;
    }
    public void ClearKitchenObject()
    {
        kithcenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kithcenObject != null;
    }
}
