using Entitas;
using Entitas.Unity;
using UnityEngine;
using System.Collections.Generic;

public sealed class DestroyHumanSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public DestroyHumanSystem (Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameObject go = entity.hasPlayer ? entity.player.value : entity.enemy.value;
            GameObject.Instantiate(contexts.game.globalVariables.value.DeathParticlePrefab, go.transform.position, Quaternion.identity);
            go.Unlink();
            GameObject.Destroy(go);
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isKilled;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Killed);
    }
}
