public class CharacterMainMenuState : BaseState<ECharacterStates>
{
    public override ECharacterStates GetStateID()
    {
        return ECharacterStates.MainMenu;
    }

    public override void OnEnterCustomActions()
    {
    }

    public override void OnExitCustomActions()
    {
    }
}