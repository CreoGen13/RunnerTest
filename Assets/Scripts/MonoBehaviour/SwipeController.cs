using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Animator playerAnimator;
    public GameObject level;
    public AnimationCurve levelCurve;
    public AnimationCurve movingCurve;
    public float animationSpeed;

    private bool isAnimating = false;
    private float maxDistance = 1;
    private Vector3 moveDistance =  new Vector3(1.15f, 0, 0);

    private Vector2 beginDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDrag = eventData.delta;
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isAnimating)
        {
            isAnimating = true;

            Vector2 swipe = beginDrag + eventData.delta;
            if (Mathf.Abs(swipe.x) > (Mathf.Abs(swipe.y)))
            {
                if (swipe.x > 0)
                    StartCoroutine(SwipeAnimation(level.transform.position.x < -maxDistance ? Vector3.zero : - moveDistance));
                else
                    StartCoroutine(SwipeAnimation(level.transform.position.x > maxDistance ? Vector3.zero : moveDistance));

            }
        }
    }
    private IEnumerator SwipeAnimation(Vector3 moveDirection)
    {
        Vector3 startPosition = level.transform.position;
        Vector3 endPosition = level.transform.position + moveDirection;
        for (float i = 0; i < 1; i += Time.deltaTime * animationSpeed)
        {
            level.transform.position = Vector3.Lerp(startPosition, endPosition, levelCurve.Evaluate(i));
            playerAnimator.SetFloat("Y", Mathf.Lerp(0, moveDirection.x > 0 ? 0.4f : -0.4f, movingCurve.Evaluate(i)));
            yield return null;
        }

        playerAnimator.SetFloat("Y", 0);
        level.transform.position = endPosition;
        isAnimating = false;
    }
    private IEnumerator StopAnimation()
    {
        float startFloatY = playerAnimator.GetFloat("Y");
        float startFloatX = playerAnimator.GetFloat("X");
        for (float i = 0; i < 1; i += Time.deltaTime * animationSpeed)
        {
            playerAnimator.SetFloat("Y", Mathf.Lerp(startFloatY, 0, levelCurve.Evaluate(i)));
            playerAnimator.SetFloat("X", Mathf.Lerp(startFloatX, 0, levelCurve.Evaluate(i)));
            yield return null;
        }

        playerAnimator.SetFloat("Y", 0);
        playerAnimator.SetFloat("X", 0);
    }
    public void Stop()
    {
        image.enabled = false;
        StopCoroutine(SwipeAnimation(Vector3.zero));
        StartCoroutine(StopAnimation());
    }
    public void DisableSwipes()
    {
        image.enabled = false;
    }
}
