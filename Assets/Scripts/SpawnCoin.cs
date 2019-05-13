using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public Transform[] coinSpawns;
    public GameObject coin;
    // Start is called before the first frame update
    private void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    private void Spawn()
    {
        for (int coinCount = 0; coinCount < coinSpawns.Length; coinCount++)
        {
            int coinFlip = Random.Range(0, 2);

            if(coinFlip > 0)
            {
                Instantiate(coin, coinSpawns[coinCount].position, Quaternion.identity);
            }
        }
    
    }
                  
        
}
