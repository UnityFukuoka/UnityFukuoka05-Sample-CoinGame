using UnityEngine;
using System.Collections;

public class FallChecker : MonoBehaviour {

    public float outPoint;
    public event System.Action fall;
    private UnityChan player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<UnityChan>();
    }

    // Update is called once per frame
    void Update () {
        if(player.transform.position.y < outPoint)fall();
    }
}
