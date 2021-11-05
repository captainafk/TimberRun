using Cinemachine;
using UnityEngine;

public class VirtualCameraBase : MonoBehaviour
{
    [SerializeField] private ECameraType _cameraType = ECameraType.None;

    private CinemachineVirtualCamera _virtualCamera;

    public ECameraType CameraType => _cameraType;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnDestroy()
    {
        Deactivate();
    }

    public void Activate()
    {
        _virtualCamera.Priority = 1;

        ActivateCustomActions();
    }

    protected virtual void ActivateCustomActions()
    {
    }

    public void Deactivate()
    {
        _virtualCamera.Priority = 0;

        DeactivateCustomActions();
    }

    protected virtual void DeactivateCustomActions()
    {
    }
}