using UnityEngine;
using System.Collections;

/// <summary>
/// 円状に回るスクリプト
/// </summary>
public class Around : MonoBehaviour {

    public Axis axis = Axis.Y;
    public Vector3 target;   // オブジェクト
    public float radius = 15.0f;    // オブジェクトからカメラまでの距離(円運動の半径)
    public float angle = 0.0f;  // ラジアン値
    public float speed = 0.01F;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = target;

        // オブジェクトの周りを円運動する
        transform.position = GetArroundPosition(pos, axis);
        angle += speed;
    }

    private Vector3 GetArroundPosition(Vector3 pos, Axis rotateAxis)
    {
        switch(rotateAxis){
        case Axis.X:
            return GetRotateX(pos);
        case Axis.Y:
            return GetRotateY(pos);
        case Axis.Z:
            return GetRotateZ(pos);
        }
        return Vector3.zero;
    }
    private Vector3 GetRotateY(Vector3 pos)
    {
        return new Vector3(pos.x + Mathf.Cos(angle) * radius, pos.y, pos.z + Mathf.Sin(angle) * radius);
    }
    
    private Vector3 GetRotateX(Vector3 pos)
    {
        return new Vector3(pos.x, pos.y  + Mathf.Cos(angle) * radius, pos.z + Mathf.Sin(angle) * radius);
    }

    private Vector3 GetRotateZ(Vector3 pos)
    {
        return new Vector3(pos.x + Mathf.Cos(angle) * radius, pos.y + Mathf.Sin(angle) * radius, pos.z);
    }

}

public enum Axis
{
    X,
    Y,
    Z
}
