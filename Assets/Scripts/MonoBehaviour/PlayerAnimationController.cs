using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;
    public AnimationCurve curve;

    public float animationSpeed;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    public void StartRunning()
    {
        StartCoroutine(Running());
    }
    private IEnumerator Running()
    {
        float startSpeed = playerAnimator.GetFloat("X");
        for (float i = 0; i < 1; i += Time.deltaTime * animationSpeed)
        {
            playerAnimator.SetFloat("X", Mathf.Lerp(startSpeed, 1, curve.Evaluate(i)));
            yield return null;
        }
        playerAnimator.SetFloat("X", 1);
    }
}
