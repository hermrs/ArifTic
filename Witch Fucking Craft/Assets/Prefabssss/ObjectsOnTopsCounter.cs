 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsOnTopsCounter : MonoBehaviour
{
    [SerializeField] private ObejctsForCounterTops kitchenObjectSo;

    private IKitchenObjectParent kithcenObjectParent;
    public ObejctsForCounterTops KitchenObjectSo()
    {
        return kitchenObjectSo;
    }
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
       if(this.kithcenObjectParent != null)
        {
            this.kithcenObjectParent.ClearKitchenObject();
        }
      
        this.kithcenObjectParent = kitchenObjectParent;
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("Tezgahta zaten bi þey var ");
        }
        kitchenObjectParent.SetKitchenObject(this);
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition= Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kithcenObjectParent;
    }
}
