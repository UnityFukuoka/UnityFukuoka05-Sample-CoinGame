using UnityEngine;
using System.Collections;

public class MainGamePreside : MonoBehaviour {

    private UnityChan player;
    // Use this for initialization
    void Start () {
        CoinCounter.Reset();
        CoinCounter.instance.disappers += OnGameClear;
        Singleton<CoinGameTimer>.Instance.timeOver += OnTimeOver;
        player = FindObjectOfType<UnityChan>();
        Singleton<FallChecker>.Instance.fall += OnTimeOver;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnGameClear()
    {
        var gameEnd = DoGameEndProcess();
        gameEnd.SetGameClear();
        player.GameClear();
    }

    void OnTimeOver()
    {
        var gameEnd = DoGameEndProcess();
        gameEnd.SetGameOver();
        player.GameOver();
    }

    private GameEndDisplayer DoGameEndProcess()
    {
        // タイマーを止める
        Singleton<CoinGameTimer>.Instance.Stop();
        
        Singleton<CameraController>.Instance.CallCamera("GameEnd");
        var gameEnd = Singleton<GameEndDisplayer>.Instance;
        gameEnd.enabled =true;
        
        return gameEnd;
    }
}
