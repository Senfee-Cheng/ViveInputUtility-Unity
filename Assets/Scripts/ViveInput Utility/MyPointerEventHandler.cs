using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyPointerEventHandler : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    void Start()
    {
      
    }

    void Update()
    {
        
    }
    
    HashSet<PointerEventData> hovers = new HashSet<PointerEventData>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hovers.Add(eventData) && hovers.Count ==1)
        {
            Debug.Log("turn to highlight state");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hovers.Remove(eventData) && hovers.Count ==0)
        {
            Debug.Log("turn to normal state");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.IsViveButton(ControllerButton.Trigger))
        {
            Debug.Log("Vive button triggered");
        }else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("standalone button triggered");
        }
    }
}
