public class CharacterLoseState : BaseState<ECharacterStates>
{
    public override ECharacterStates GetStateID()
    {
        return ECharacterStates.Lose;
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