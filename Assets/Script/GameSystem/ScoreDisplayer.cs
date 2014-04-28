using UnityEngine;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour {
    void OnGUI () {
        GUI.Box(new Rect(Screen.width - 110, 10,100,90), "Coin");
        
        var style = new GUIStyle();
        style.fontSize = 32;
        var state = new GUIStyleState();
        state.textColor = Color.white;
        style.normal = state;
        GUI.Label(new Rect(Screen.width - 85, 40, 100, 200), 
            CoinCounter.instance.count.ToString() + "/" + CoinCounter.instance.max,
            style); 
    }
}
