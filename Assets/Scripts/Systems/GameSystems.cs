public sealed class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        //--------INITIALIZE--------
        Add(new CreatePlayerSystem(contexts));
        Add(new CreateLevelPartSystem(contexts));
        //--------INPUT--------
        //--------UPDATE--------
        Add(new ChangeLevelSystem(contexts));
        Add(new BattleSystems(contexts));
        Add(new CollectingSystem(contexts));
        Add(new GameEndSystem(contexts));
        //--------VIEW--------
        //--------CLEANUP--------
        Add(new DestroyItemSystem(contexts));
        Add(new DestroyTriggerSystem(contexts));
        Add(new DestroyHumanSystem(contexts));
    }
}