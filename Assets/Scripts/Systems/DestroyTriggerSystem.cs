using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class DestroyTriggerSystem : ReactiveSystem<GameEntity>
{
    public DestroyTriggerSystem(Contexts contexts) : base(contexts.game) {}

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.StartBattle, GameMatcher.Battle, GameMatcher.EndBattle, GameMatcher.GameEnd));
    }
}
