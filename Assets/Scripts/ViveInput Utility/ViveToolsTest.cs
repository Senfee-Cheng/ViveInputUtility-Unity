using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.Vive;
using UnityEngine;

public class ViveToolsTest : MonoBehaviour
{
    void Start()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Trigger, ButtonEventType.Up, OnTrigger);
    }
    
    private void OnDestroy()
    {
        ViveInput.RemoveListenerEx(HandRole.RightHand, ControllerButton.Trigger, ButtonEventType.Up, OnTrigger);
    }

    private void OnTrigger()
    {
        Debug.Log("Add Listen");
    }

    void Update()
    {
        // get trigger down
        if (ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
        {
            Debug.Log("Right Trigger Down");
        }

        //get trigger axis value
        if (ViveInput.GetAxisEx(HandRole.RightHand, ControllerAxis.Trigger) > 0.5f)
        {
            Debug.Log("Axis ex value");
        }

        RigidPose pose1 = VivePose.GetPoseEx(HandRole.RightHand);
        RigidPose pose2 = VivePose.GetPoseEx(TrackerRole.Tracker1);

        if (VivePose.IsValidEx(HandRole.RightHand) && VivePose.IsValidEx(TrackerRole.Tracker1))
        {
            transform.localPosition = Vector3.Lerp(pose1.pos,pose2.pos,.5f);
            transform.localRotation = Quaternion.Lerp(pose1.rot,pose2.rot,.5f);
        }
    }

  
}