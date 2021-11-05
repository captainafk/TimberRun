public class CharacterWinState : BaseState<ECharacterStates>
{
    public override ECharacterStates GetStateID()
    {
        return ECharacterStates.Win;
    }

    public override void OnEnterCustomActions()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExitCustomActions()
    {
        throw new System.NotImplementedException();
    }
}