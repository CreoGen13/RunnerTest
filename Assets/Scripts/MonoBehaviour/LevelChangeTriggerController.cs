using Entitas.Unity;
using UnityEngine;

public class LevelChangeTriggerController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FirstPart" || other.tag == "SecondPart")
        {
            ((GameEntity)other.gameObject.transform.parent.gameObject.GetComponentInParent<Transform>().gameObject.GetEntityLink().entity).isChangedLevel = true;
        }
    }
}
