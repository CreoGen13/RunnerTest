using Entitas;
using Entitas.Unity;
using UnityEngine;
using System.Collections.Generic;

public sealed class DestroyItemSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public DestroyItemSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.item.value.Unlink();
            GameObject.Destroy(entity.item.value);
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasItem;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }
}
