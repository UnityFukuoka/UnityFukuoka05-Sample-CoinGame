using UnityEngine;
using System.Collections;

public class CoinComponent : MonoBehaviour {

    public GameObject coinGetSound;
    void Update()
    {
        // その場で回転する
        transform.Rotate(Vector3.up,1F);
    }

	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag != "Player")return;
        CoinCounter.instance.Decriment();
        var sound = Instantiate(coinGetSound) as GameObject;
        Destroy(sound,1.5F);
        
        Object.Destroy(this.gameObject);
	}
}
