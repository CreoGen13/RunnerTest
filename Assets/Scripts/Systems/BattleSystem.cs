using Entitas;
using System.Collections.Generic;
using UnityEngine;

public sealed class BattleSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public BattleSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if(entity.isFight)
            {
                var animator = entity.enemy.value.GetComponent<Animator>();
                animator.SetTrigger("Dead");
            }
            else
            {
                var animator = entity.enemy.value.GetComponent<Animator>();
                animator.SetTrigger("Bribed");
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEnemy;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Bribe, GameMatcher.Fight));
    }
}
