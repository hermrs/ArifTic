using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        PlayerV2.Instance.OnSelectedcounterChanged += Instance_OnSelectedcounterChanged;
    }

    private void Instance_OnSelectedcounterChanged(object sender, PlayerV2.OnSelectedCounterChangeEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
        
    } 
    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
