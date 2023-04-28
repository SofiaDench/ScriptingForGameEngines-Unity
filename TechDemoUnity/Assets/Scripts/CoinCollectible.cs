using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{

    public int coins;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public void OnTriggerEnter( Collider Col )    //this solution means that the Coins collider must have "is a trigger" clicked on
    {
        if (Col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            coins = coins + 1;
            Col.gameObject.SetActive(false);
        }
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
