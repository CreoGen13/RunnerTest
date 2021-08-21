using Entitas;
using Entitas.Unity;
using UnityEngine;

public sealed class CreatePlayerSystem : IInitializeSystem
{
    readonly Contexts contexts;
    public CreatePlayerSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }
    public void Initialize()
    {
        var entity = contexts.game.CreateEntity();
        var player = contexts.game.globalVariables.value.Player;

        entity.AddPlayer(player);
        entity.player.value.Link(entity);
    }
}
