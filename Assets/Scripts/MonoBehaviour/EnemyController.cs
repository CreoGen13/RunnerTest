using Entitas.Unity;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool activated = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !activated)
        {
            activated = true;

            var entity = GameController.contexts.game.CreateEntity();
            entity.isStartBattle = true;

            ((GameEntity)gameObject.GetEntityLink().entity).isFightingEnemy = true;
        }
    }
    public void FightAnimation()
    {
        GameController.contexts.game.CreateEntity().AddEndBattle(((GameEntity)gameObject.GetEntityLink().entity).enemy.isFirstPart);
        
        ((GameEntity)gameObject.GetEntityLink().entity).isKilled = true;
    }
    public void BribeAnimation()
    {
        gameObject.GetComponent<SkinnedMeshRenderer>().material = GameController.contexts.game.globalVariables.value.glowFadingMaterial;
        StartCoroutine(BribeCoroutine());
    }
    private IEnumerator BribeCoroutine()
    {
        yield return new WaitForSeconds(2f);

        GameController.contexts.game.CreateEntity().AddEndBattle(((GameEntity)gameObject.GetEntityLink().entity).enemy.isFirstPart);
        ((GameEntity)gameObject.GetEntityLink().entity).isKilled = true;
    }
}
