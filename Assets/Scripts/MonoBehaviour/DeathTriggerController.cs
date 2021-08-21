using Entitas.Unity;
using UnityEngine;

public class DeathTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ((GameEntity)other.gameObject.GetEntityLink().entity).isKilled = true;
            GameController.contexts.game.CreateEntity().isGameEnd = true;
        }
    }
}
