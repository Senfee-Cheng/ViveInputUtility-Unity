using System;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
using UnityEngine;

namespace ViveInput_Utility
{
    public class PrintDeviceState_VRModule:MonoBehaviour
    {
        private uint m_deviceIndex;

        private void Update()
        {
            var deviceIndex = ViveRole.GetDeviceIndexEx(HandRole.RightHand);

            if (m_deviceIndex!=deviceIndex)
            {
                m_deviceIndex = deviceIndex;

                if (VRModule.IsValidDeviceIndex(deviceIndex))
                {
                    var deviceState = VRModule.GetDeviceState(deviceIndex);
                    Debug.Log("HandRole.RightHand is now mapped to device "+ deviceIndex);
                    Debug.Log("SerialNumber="+deviceState.serialNumber);
                    Debug.Log("ModelNumber="+deviceState.modelNumber);
                    Debug.Log("RenderModelName="+deviceState.renderModelName);
                    Debug.Log("deviceClass="+deviceState.deviceClass);
                    Debug.Log("deviceModel="+deviceState.deviceModel);
                }
                else
                {
                    Debug.Log("HandRole.RightHand is now mapped to invalid device");
                }
                
            }
            else
            {
                if (VRModule.IsValidDeviceIndex(deviceIndex))
                {
                    var deviceState = VRModule.GetDeviceState(deviceIndex);
                    Debug.Log("velocity="+deviceState.velocity);
                    Debug.Log("angularVelocity="+deviceState.angularVelocity);
                    Debug.Log("position="+deviceState.position);
                    Debug.Log("rotation="+deviceState.rotation);
                    Debug.Log("Button Pressed="+deviceState.buttonPressed);
                    Debug.Log("ButtonTouched="+deviceState.buttonTouched);
                }
            }
        }
    }
}