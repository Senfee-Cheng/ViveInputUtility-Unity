using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionInputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Actions.default_GrabGrip.onStateDown += DefaultGrabGripOnOnStateDown;
        SteamVR_Actions.default_GrabGrip.onStateUp += DefaultGrabGripOnOnStateUp;
    }

    private void DefaultGrabGripOnOnStateUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
    {
        Debug.Log("DefaultGrabGripOnOnStateUp - " + fromaction.activeDevice + (fromsource == SteamVR_Input_Sources.Any));
    }

    private void DefaultGrabGripOnOnStateDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
    {
        Debug.Log("DefaultGrabGripOnOnStateDown - " + fromaction.activeDevice +(fromsource == SteamVR_Input_Sources.Any));
    }

    void Update()
    {
        
    }
}