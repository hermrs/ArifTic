using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[SerializeField]

public class PlayerV2 : MonoBehaviour
{
    private bool isWalking;

    [SerializeField]  private GameInputV2 gameInput;
    [SerializeField]  private float playerSpeed = 7f;
    [SerializeField]  private float rotateSpeed = 12f;
    private void Update()
    {
       Vector2 inputVector = gameInput.GetMovementVectorNormalized();
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
