using UnityEngine;
using System.Collections;

/// <summary>
/// はねる挙動をつけるコンポーネント
/// </summary>
public class Bound : MonoBehaviour {

    public float power;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter(Collision other)
    {
        // 真上の方向に力を加える
        rigidbody.AddForce(Vector3.up* power, ForceMode.VelocityChange);
    }
}
