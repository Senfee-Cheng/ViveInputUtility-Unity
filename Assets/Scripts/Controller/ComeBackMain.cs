using System.Collections;
using System.Collections.Generic;
using Michsky.UI.Shift;
using UnityEngine;
using UnityEngine.UIElements;

public class ComeBackMain : MonoBehaviour
{
    public ModalWindowManager _winManager;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            BtnClick();
        }
    }

    public void BtnClick()
    {
        
        _winManager.ModalWindowIn();
    }
}
