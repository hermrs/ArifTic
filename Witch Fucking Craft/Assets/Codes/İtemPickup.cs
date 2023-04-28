using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İtemPickup : MonoBehaviour
{
    public İtem İtem;

    void Pickup()
    {
        İnventoryManager.Instance.Add(İtem);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        Pickup();  
    }
}
