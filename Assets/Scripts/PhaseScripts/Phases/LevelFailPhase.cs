using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPhase : BasePhase
{
    public override void OnEnterCustomActions()
    {
        Debug.Log("Level Fail Phase");
    }

    public override void OnExitCustomActions()
    {

    }
}
