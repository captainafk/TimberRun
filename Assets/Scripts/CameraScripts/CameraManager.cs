using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private ECameraType _initialCamera = ECameraType.None;

    private List<VirtualCameraBase> _virtualCameraList;

    private void Awake()
    {
        _virtualCameraList = FindObjectsOfType<VirtualCameraBase>().ToList();

        ActivateCamera(new CameraActivationArgs(_initialCamera));
    }

    public void ActivateCamera(CameraActivationArgs activationArgs)
    {
        DeactivateAllCameras();

        VirtualCameraBase virtualCamera = _virtualCameraList
            .SingleOrDefault(v => v.CameraType == activationArgs.CameraType);

        virtualCamera.Activate();
    }

    private void DeactivateAllCameras()
    {
        _virtualCameraList.ForEach(v => v.Deactivate());
    }
}