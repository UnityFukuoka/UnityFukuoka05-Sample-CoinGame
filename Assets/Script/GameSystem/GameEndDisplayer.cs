using UnityEngine;
using System.Collections;

public class GameEndDisplayer : MonoBehaviour {

    private string state;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
    
    }

    void OnGUI()
    {
        var style = new GUIStyle();
        style.fontSize = 64;
        GUI.Box(new Rect(Screen.width / 2F - 200, 10,300,50), state,style);

        if(GUI.Button(new Rect(100,300,120,32), "Retry"))
        {
            Application.LoadLevel("Main");
        }
        else if(GUI.Button(new Rect(Screen.width - 220,300,120,32), "Exit"))
        {
            Application.Quit();
        }
    }
    
    public void SetGameClear()
    {
        state = "Game Clear !";
    }
    
    public void SetGameOver()
    {
        state = "Game Over ...";
    }
}
