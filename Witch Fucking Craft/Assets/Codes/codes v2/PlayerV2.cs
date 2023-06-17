using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[SerializeField]

public class PlayerV2 : MonoBehaviour, IKitchenObjectParent
{
    private bool isWalking;
   
    [SerializeField]  private GameInputV2 gameInput;
    [SerializeField]  private float playerSpeed = 7f;
    [SerializeField]  private float rotateSpeed = 12f;
    [SerializeField]  private GameObject pivot;
    [SerializeField]  private float playerRadius = 0.07f;
    [SerializeField]  private float playerHeight = 2f;
    [SerializeField]  private float interactDistance = 1f;
    [SerializeField] private LayerMask countersLayerMask;

    [SerializeField] private ObejctsForCounterTops counterTopsThings;
    [SerializeField] private Transform KitchenObjectHoldPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;
    private ObjectsOnTopsCounter kithcenObject;
    private Vector3 lastIntDir;
    private ClearCounter selectedCounter;
    public event EventHandler<OnSelectedCounterChangeEventArgs> OnSelectedcounterChanged;
    public class OnSelectedCounterChangeEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }
    private static PlayerV2 instance;
    public static PlayerV2 Instance { get; private set; }

    private void Awake()
    {
       if(Instance != null)
        {
            Debug.LogError("Birden fazla oyuncu varlýk gösteriyor ?:/");
        }
        Instance = this; 
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
       if(selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastIntDir = moveDir;
        }
        if (Physics.Raycast(pivot.transform.position, moveDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // boþ tezhasa buyara atmalý ??
                clearCounter.Interact(this);
            }

        }
        else
        {
            // Debug.Log("-");
        }
    }
    private void Update()
    {
        HandleMovement(); 
        HandleInteractions();
    }
    public bool IsWalking() {
        return isWalking;
    }
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if(moveDir != Vector3.zero)
        {
            lastIntDir = moveDir;
        }
       if (Physics.Raycast(pivot.transform.position, moveDir,out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
           if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
           {
                // boþ tezhasa buyara atmalý ??
                if(clearCounter != selectedCounter)
                {
                   SetSelectedCounter(clearCounter);
                   
                }
                
           }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
        //Debug.Log(selectedCounter);

    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        // Raycast deneme alaný 
       /* float range = 5;
        Vector3 direction = Vector3.forward;
        Vector3 origins = new Vector3(transform.position.x,pivot.transform.position.y  ,transform.position.z);
        Ray theRay = new Ray(pivot.transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(pivot.transform.position, transform.TransformDirection(transform.forward * range)); */
        // Raycast deneme alaný1

        float moveDistance = playerSpeed * Time.deltaTime;
        isWalking = moveDir != Vector3.zero;
        float playerSize = .7f;
        // bi ara bak buraya arada kutularýn içinden geçebiliyorsun
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (!canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    moveDir = Vector3.zero;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * Time.deltaTime * playerSpeed;
        }
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        // test f*cking everything   Debug.Log(Time.deltaTime);

    }
    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedcounterChanged?.Invoke(this, new OnSelectedCounterChangeEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return KitchenObjectHoldPoint;
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
