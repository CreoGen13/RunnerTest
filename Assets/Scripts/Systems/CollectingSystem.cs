using Entitas;
using System.Collections.Generic;

public sealed class CollectingSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public CollectingSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            //entity.item.value.Unlink();
            //GameObject.Destroy(entity.item.value);
            //entity.Destroy();
            entity.isDestroyed = true;
            int value = int.Parse(contexts.game.globalVariables.value.ScoreText.text);
            value++;
            contexts.game.globalVariables.value.ScoreText.text = value.ToString();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCollected;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collected);
    }
}
