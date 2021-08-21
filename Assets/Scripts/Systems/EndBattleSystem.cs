using Entitas;
using System.Collections.Generic;
using UnityEngine.UI;

public sealed class EndBattleSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public EndBattleSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var endBattle in entities)
        {
            foreach(var entity in contexts.game.GetEntities())
            {
                if (entity.hasEnemy && entity.enemy.isFirstPart == endBattle.endBattle.isFirstPart)
                    entity.isKilled = true;
            }

            contexts.game.globalVariables.value.Level.speed = 1;
            contexts.game.globalVariables.value.SwipeControllerGameObject.GetComponent<Image>().enabled = true;
            contexts.game.globalVariables.value.Player.GetComponent<PlayerAnimationController>().StartRunning();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEndBattle;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EndBattle);
    }
}
