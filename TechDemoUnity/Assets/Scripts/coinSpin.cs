using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpin : MonoBehaviour //Coin Spinning solution
{
    
   
    void Start()
    {
        
    }


     void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
     }

   
}
