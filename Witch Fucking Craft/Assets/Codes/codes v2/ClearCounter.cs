using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ClearCounter : MonoBehaviour,  IKitchenObjectParent
{
   
    [SerializeField] private ObejctsForCounterTops counterTopsThings;
   [SerializeField] private Transform counterTopPoint;
   [SerializeField] private ClearCounter secondClearCounter;
   [SerializeField] private bool testing;
    private ObjectsOnTopsCounter kithcenObject;
    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.Q))
        {
            if(kithcenObject != null)
            {
               // kithcenObject.seta
            }
        }
    }
    public void Interact(PlayerV2 player)
    {
        if (kithcenObject == null)
        {
            Transform AletTransform = Instantiate(counterTopsThings.prefab, counterTopPoint);
            AletTransform.GetComponent<ObjectsOnTopsCounter>().SetKitchenObjectParent(this);
            AletTransform.localPosition = Vector3.zero;
            kithcenObject = AletTransform.GetComponent<ObjectsOnTopsCounter>();
            kithcenObject.SetKitchenObjectParent(this);
            
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
    public void SetKitchenObject(ObjectsOnTopsCounter kitchenObject)
    {
        this.kithcenObject = kitchenObject;
    }
    public ObjectsOnTopsCounter GetKitchenObject()
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
