using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.VRModuleManagement;
using UnityEngine;

/// <summary>
/// 自定义设备的高度和前后距离
/// </summary>
public class CustomDeviceLocation : MonoBehaviour
{
    [SerializeField] private float m_height = -1.1f;
    [SerializeField] private float m_around = 0f;
    [SerializeField] private float m_about = 0f;

    /// <summary>
    /// 设备高度
    /// </summary>
    public float height
    {
        get { return m_height; }
        set
        {
            if (ChangeProp.Set(ref m_height, value))
            {
                UpdateHeight();
            }
        }
    }

    /// <summary>
    /// 设备前后距离
    /// </summary>
    public float around
    {
        get { return m_around; }
        set
        {
            if (ChangeProp.Set(ref m_around, value))
            {
                UpdateHeight();
            }
        }
    }

    /// <summary>
    /// 设备左右距离
    /// </summary>
    public float about
    {
        get => m_about;
        set
        {
            if (ChangeProp.Set(ref m_about, value))
            {
                UpdateHeight();
            }
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        if (Application.isPlaying && isActiveAndEnabled && VRModule.Active)
        {
            UpdateHeight();
        }
    }
#endif

    private void OnEnable()
    {
        VRModule.onActiveModuleChanged += OnActiveModuleChanged;
        VRModule.Initialize();

        UpdateHeight();
    }

    private void OnDisable()
    {
        VRModule.onActiveModuleChanged -= OnActiveModuleChanged;
    }

    private void OnActiveModuleChanged(VRModuleActiveEnum activeModule)
    {
        UpdateHeight();
    }

    public void UpdateHeight()
    {
        var pos = transform.localPosition;
        Debug.Log("检测到激活的设备：" + VRModule.activeModule);
        switch (VRModule.activeModule)
        {
#if UNITY_2019_3_OR_NEWER
            case VRModuleActiveEnum.SteamVR:
                transform.localPosition = new Vector3(about, height, around);
                Debug.LogFormat(VRModule.activeModule + "前后:{0},左右:{1},上下:{2}", around, about, height);
                break;

#endif
        }
    }
}