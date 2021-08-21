using Entitas;
using UnityEngine;
using System.Collections.Generic;
using Entitas.Unity;

public sealed class ChangeLevelSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public ChangeLevelSystem(Contexts contexts) : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Transform[] children = entity.levelPart.value.GetComponentsInChildren<Transform>();
            for(int i = 2; i < children.Length; i++)
            {
                if(children[i].gameObject.GetEntityLink() != null)
                    ((GameEntity)children[i].gameObject.GetEntityLink()?.entity).isDestroyed = true;
            }
            GameObject.Destroy(children[1].gameObject);

            GameObject floor = GameObject.Instantiate(Randomize(), entity.levelPart.value.transform);
            floor.tag = entity.levelPart.isFirstPart ? "FirstPart" : "SecondPart";

            var coin = contexts.game.CreateEntity();
            coin.AddItem(GameObject.Instantiate(contexts.game.globalVariables.value.CoinPrefab, entity.levelPart.value.transform));
            coin.item.value.transform.localPosition = new Vector3(1.15f * Random.Range(-1, 2), 1, -5);
            coin.item.value.Link(coin);

            GameEntity[] enemies = new GameEntity[Random.Range(1, 4)];
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = contexts.game.CreateEntity();
                var enemy = GameObject.Instantiate(contexts.game.globalVariables.value.EnemyPrefab, entity.levelPart.value.transform);
                enemies[i].AddItem(enemy);
                enemies[i].AddEnemy(enemy, entity.levelPart.isFirstPart);
                enemies[i].enemy.value.Link(enemies[i]);
            }
            Replace(enemies);
            entity.isChangedLevel = false;
        }
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isChangedLevel;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.LevelPart, GameMatcher.ChangedLevel));
    }

    private GameObject Randomize()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                return contexts.game.globalVariables.value.LevelVariant1;
            case 2:
                return contexts.game.globalVariables.value.LevelVariant2;
            case 3:
                return contexts.game.globalVariables.value.LevelVariant3;
            default:
                return contexts.game.globalVariables.value.LevelVariant4;
        }
    }
    private void Replace(GameEntity [] entities)
    {
        bool[] positions = new bool[3];
        for (int i = 0; i < entities.Length;)
        {
            int position = Random.Range(-1, 2);
            if (!positions[position + 1])
            {
                entities[i].enemy.value.transform.localPosition = new Vector3(1.15f * position, 0.5f, -1);
                positions[position + 1] = true;
                i++;
            }
        }
    }
}