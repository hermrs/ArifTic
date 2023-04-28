using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpİtems : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;

    public float pickUpDistance;
    public float forceMulti;

    public bool readyToThorow;
    public bool itemsPicked;

    private Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && itemsPicked==true && readyToThorow)
        {
            forceMulti += 300 * Time.deltaTime;
        }
    }
}
