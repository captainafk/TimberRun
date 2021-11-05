using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhase : BasePhase
{
    public override void OnEnterCustomActions()
    {
        Debug.Log("Game Phase");
    }

    public override void OnExitCustomActions()
    {
        
    }
}
