using UnityEngine;
using System.Collections;

public class CoinGameTimer : MonoBehaviour {
    public float timeLimit;
    private float nowTime;
    private bool isStop;
    
    public event System.Action timeOver;
	// Use this for initialization
	void Start () {
        nowTime = timeLimit;
	}
	
	// Update is called once per frame
	void Update () {
        if(isStop)return;
        nowTime -= Time.deltaTime;
        if(nowTime <= 0F) { timeOver(); gameObject.SetActive(false); }
    }

    void OnGUI()
    {
        var style = new GUIStyle();
        style.fontSize = 32;

        GUI.TextArea(new Rect(Screen.width/2-64, Screen.height-32,128,32), "TIME:" + nowTime.ToString("F1"), style);
    }
    
    public void Stop()
    {
        isStop = true;
    }
}
