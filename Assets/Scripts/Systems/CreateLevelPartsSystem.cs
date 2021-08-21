using Entitas;
using Entitas.Unity;

public sealed class CreateLevelPartSystem : IInitializeSystem
{
    readonly Contexts contexts;
    public CreateLevelPartSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }
    public void Initialize()
    {
        var levelPart1 = contexts.game.CreateEntity();
        var levelPart2 = contexts.game.CreateEntity();

        levelPart1.AddLevelPart(contexts.game.globalVariables.value.LevelPart1, true);
        contexts.game.globalVariables.value.LevelPart1.Link(levelPart1);
        levelPart2.AddLevelPart(contexts.game.globalVariables.value.LevelPart2, false);
        contexts.game.globalVariables.value.LevelPart2.Link(levelPart2);
    }
}
