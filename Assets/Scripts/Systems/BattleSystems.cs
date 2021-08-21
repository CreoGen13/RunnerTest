public sealed class BattleSystems : Feature
{
    public BattleSystems(Contexts contexts)
    {
        Add(new StartBattleSystem(contexts));
        Add(new BattleSystem(contexts));
        Add(new EndBattleSystem(contexts));
    }
}