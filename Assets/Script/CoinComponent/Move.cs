using UnityEngine;
using System.Collections;

/// <summary>
/// 目的地まで移動するスクリプト
/// </summary>
public class Move : MonoBehaviour {

    // 移動速度
    public float speed;
    public Vector3[] arrivedPoints;
    private int nowArrived=0;
    private Vector3 arrivedPoint;
    // Use this for initialization
    void Start () {
        arrivedPoint = arrivedPoints[nowArrived];
    }

    // Update is called once per frame
    void Update () {
        var forward = (arrivedPoint - transform.position).normalized;
        transform.position += forward * speed;
        if(Vector3.Distance(transform.position, arrivedPoint) <= speed)
        {
            nowArrived = nowArrived >= arrivedPoints.Length - 1 ? 0 : nowArrived + 1;
            arrivedPoint = arrivedPoints[nowArrived];
        }
    }
}
