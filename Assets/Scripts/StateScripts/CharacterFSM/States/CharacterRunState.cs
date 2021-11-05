using UnityEngine;

public class CharacterRunState : BaseState<ECharacterStates>
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _sidewaysMoveSpeed = 5f;
    [SerializeField] private float _sidewaysDeltaMultiplier = 2f;
    [SerializeField] private float _additionalYSpeedAmount = -1f;

    private float _curSidewaysMoveSliderVal = 0;

    public override ECharacterStates GetStateID()
    {
        return ECharacterStates.Run;
    }

    private void Awake()
    {
        PhaseFlowManager.Instance.OnPhaseStarted += SetTransitionToRunState;
    }

    private void Update()
    {
        TryMove();
    }

    private void SetTransitionToRunState(BasePhase phase)
    {
        if (phase is GamePhase)
        {
            StateManager.SetTransition(ECharacterStates.MainMenu,
                                       ECharacterStates.Run);
        }
    }

    public override void OnEnterCustomActions()
    {
        _inputController.OnInputContinued += OnInputContinued;
    }

    public override void OnExitCustomActions()
    {
        _inputController.OnInputContinued -= OnInputContinued;
    }

    private void OnInputContinued(Vector2 coord)
    {
        _curSidewaysMoveSliderVal += coord.x * _sidewaysDeltaMultiplier;

        _curSidewaysMoveSliderVal = Mathf.Clamp(_curSidewaysMoveSliderVal,
            LevelBoundaryProvider.Instance.GetLeftBoundary().x,
            LevelBoundaryProvider.Instance.GetRightBoundary().x);
    }

    private bool TryMove()
    {
        if (!CanMove()) return false;

        Vector3 sideWayDir = _playerTransform.right * (_curSidewaysMoveSliderVal - _playerTransform.position.x);

        _playerMovementBehaviour.Move(_playerTransform.forward * _speed +
                                      sideWayDir * _sidewaysMoveSpeed +
                                      new Vector3(0, _additionalYSpeedAmount, 0));

        return true;
    }

    private bool CanMove()
    {
        return StateManager.GetCurrentStateID().Equals(GetStateID());
    }
}