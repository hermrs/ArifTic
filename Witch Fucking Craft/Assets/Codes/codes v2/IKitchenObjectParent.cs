using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform GetKitchenObjectFollowTransform();


    public void SetKitchenObject(KitchenObje kitchenObject);


    public KitchenObje GetKitchenObject();


    public void ClearKitchenObject();


    public bool HasKitchenObject();
    
}
