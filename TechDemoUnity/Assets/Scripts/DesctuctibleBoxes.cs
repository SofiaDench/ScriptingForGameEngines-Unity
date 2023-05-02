using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesctuctibleBoxes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this);
            Debug.Log("is colliding");
        }
    }

}
