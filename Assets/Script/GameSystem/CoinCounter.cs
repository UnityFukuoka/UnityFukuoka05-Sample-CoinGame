using System;
using UnityEngine;

public class CoinCounter  {
    private static CoinCounter coinCounter;
    /// <summary>
    /// コインが全て無くなる
    /// </summary>
    public event Action disappers;
    public int count
    {
        get;
        private set;
    }
    public int max
    {
        get;
        private set;
    }

    private CoinCounter(){
        count = GameObject.FindObjectsOfType<CoinComponent>().Length;
        max = count;
    }
    
    public static void Reset()
    {
        coinCounter = new CoinCounter();
    }

	public static CoinCounter instance {
        get
        {
            if(CoinCounter.coinCounter == null) CoinCounter.coinCounter = new CoinCounter();
            return CoinCounter.coinCounter;
        }
    }

    public void Add(){
        count++;
    }

    public void Decriment()
    {
        count--;
        if(count <= 0) { disappers(); }
    }
}
