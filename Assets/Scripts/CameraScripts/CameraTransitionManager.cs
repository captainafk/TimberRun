using UnityEngine;

public class CameraTransitionManager : MonoBehaviour
{
    private void Awake()
    {
        RegisterToEvents();
    }

    private void OnDestroy()
    {
        UnregisterFromEvents();
    }

    private void RegisterToEvents()
    {
        PhaseFlowManager.Instance.OnPhaseStarted += OnPhaseStarted;
    }

    private void UnregisterFromEvents()
    {
        PhaseFlowManager.Instance.OnPhaseStarted -= OnPhaseStarted;
    }

    private void OnPhaseStarted(BasePhase phase)
    {
        if (phase is GamePhase)
        {
            GameCameraTransition();
        }
        else if (phase is CheckLevelSuccessPhase)
        {
            CheckLevelSuccessPhaseCameraTransition();
        }
    }

    private void GameCameraTransition()
    {
        CameraManager.Instance.ActivateCamera(new CameraActivationArgs(ECameraType.Game));
    }

    private void CheckLevelSuccessPhaseCameraTransition()
    {
        CameraManager.Instance.ActivateCamera(new CameraActivationArgs(ECameraType.EndGame));
    }
}