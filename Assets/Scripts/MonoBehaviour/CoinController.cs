using Entitas.Unity;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            ((GameEntity)gameObject.GetEntityLink().entity).isCollected = true;
    }
}
