using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Oyuncu Hýzý")]
    [SerializeField] private float playerSpeed=7f;
    private void Update()
    {
       Vector2 inputVector = new Vector2(0,0);
      // üst sanal alt real 
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.x = -1;
           // inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.y = -1;
            //inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.x = +1;

           // inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.y = +1;
           // inputVector.x = +1;
        }
        Vector3 inputVector3D = new Vector3(inputVector.x, 0f, inputVector.y);
        inputVector=inputVector.normalized;
        transform.position += inputVector3D * Time.deltaTime * playerSpeed;
    }
}
