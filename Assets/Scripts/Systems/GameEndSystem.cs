using Entitas;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEndSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public GameEndSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            contexts.game.globalVariables.value.SwipeControllerGameObject.GetComponent<SwipeController>().DisableSwipes();
            contexts.game.globalVariables.value.Level.speed = 0;

            contexts.game.globalVariables.value.GameOver.GetComponent<Animator>().SetTrigger("GameOver");
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameEnd;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameEnd);
    }
}
