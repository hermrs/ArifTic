using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform GetKitchenObjectFollowTransform();


    public void SetKitchenObject(ObjectsOnTopsCounter kitchenObject);


    public ObjectsOnTopsCounter GetKitchenObject();


    public void ClearKitchenObject();


    public bool HasKitchenObject();
    
}
