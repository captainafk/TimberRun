using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private bool _areInputsEnabled = true;

    private Vector2 _fingerLastPosition = Vector2.zero;
    private Vector2 _fingerPositionDifference = Vector2.zero;

    public Action<Vector2> OnInputStarted;
    public Action<Vector2> OnInputContinued;
    public Action<Vector2> OnInputFinished;

    private void Update()
    {
        if (!_areInputsEnabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            _fingerLastPosition.x = Input.mousePosition.x;
            _fingerLastPosition.y = Input.mousePosition.y;

            OnInputStarted?.Invoke(_fingerLastPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 fingerNewPosition = Input.mousePosition;
            _fingerPositionDifference = fingerNewPosition - _fingerLastPosition;
            _fingerLastPosition = fingerNewPosition;

            OnInputContinued?.Invoke(_fingerPositionDifference);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _fingerLastPosition = Input.mousePosition;

            OnInputFinished?.Invoke(_fingerLastPosition);
        }
    }

    public void EnableInput() => _areInputsEnabled = true;

    public void DisableInput() => _areInputsEnabled = false;
}