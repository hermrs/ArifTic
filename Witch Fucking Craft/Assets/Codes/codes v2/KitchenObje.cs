using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class KitchenObje : MonoBehaviour
{
    [SerializeField] private ObejctsForCounterTops kitchenObjectSO;
    
    private IKitchenObjectParent kitchenObjectParent;

    public ObejctsForCounterTops GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter Already has a KitchenObj");
        }
        kitchenObjectParent.SetKitchenObject(this);
        
        transform.parent=kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition= Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
