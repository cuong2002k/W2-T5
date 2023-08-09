using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AnimationCurve animationCurve;
    private Vector3 initalScale;
    private Vector3 finalScale;
    float graphValue;
    private void Awake()
    {
        initalScale = this.transform.localScale;
        finalScale = Vector3.one * 4f;
        animationCurve.postWrapMode = WrapMode.PingPong;
    }
    private void Update()
    {
        graphValue = animationCurve.Evaluate(Time.time);
        this.transform.localScale = graphValue * finalScale;
    }
}
