using UnityEngine;

public abstract class BasePhase : MonoBehaviour
{
    public abstract void OnEnterCustomActions();

    public abstract void OnExitCustomActions();

    public void OnEnterActions()
    {
        OnEnterCustomActions();
    }

    public void OnExitActions()
    {
        OnExitCustomActions();
    }
}