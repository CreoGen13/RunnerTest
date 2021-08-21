using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class StartBattleSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public StartBattleSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            contexts.game.globalVariables.value.SwipeControllerGameObject.GetComponent<SwipeController>().Stop();
            contexts.game.globalVariables.value.Level.speed = 0;

            contexts.game.globalVariables.value.BattleButtons.GetComponent<Animator>().SetTrigger("FadeIn");

            contexts.game.CreateEntity().isBattle = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isStartBattle;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.StartBattle);
    }
}
