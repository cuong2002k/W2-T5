using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEffect : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float time = 0.5f;

    public float timeTransition = 1f;

    public Vector3 initalTranform;
    public Vector3 finalTranform;

    private void Awake()
    {
        initalTranform = this.transform.position;
    }

    private void Start()
    {
        StartCoroutine(transitionEffect());
        animationCurve.postWrapMode = WrapMode.PingPong;
    }
    IEnumerator transitionEffect()
    {
        float i = 0;
        float rate = 1 / time;
        while (i < timeTransition)
        {
            i += rate * Time.deltaTime;
            this.transform.position = Vector3.Lerp(initalTranform, finalTranform, animationCurve.Evaluate(i));
            yield return 0;
        }

    }


}
