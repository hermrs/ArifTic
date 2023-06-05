using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[SerializeField]

public class PlayerV2 : MonoBehaviour
{
    private bool isWalking; 
    [SerializeField]
    private float playerSpeed = 7f;
    private float rotateSpeed = 12f;
    private void Update()
    {
        Vector2 inputVector = new Vector2(0,0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x,0f,inputVector.y);
        transform.position += moveDir * Time.deltaTime * playerSpeed;
        isWalking= moveDir != Vector3.zero;
        
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotateSpeed)  ;
     // test f*cking everything   Debug.Log(Time.deltaTime);
    }
    public bool IsWalking() {
        return isWalking;
    }
}
