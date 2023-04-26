using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private GameObject MyObj;
    public List<GameObject> Sandwiches = new List<GameObject>();
    public List<Rigidbody> Rigidbodies = new List<Rigidbody>();
    // Update is called once per frame
    void Start()
    {
       // MyObj = GameObject.Find("ParentGO").transform.Find("Sandwich").gameObject;

        foreach (var item in GameObject.FindGameObjectsWithTag("Sandwich"))
        {
            Rigidbody R = item.AddComponent<Rigidbody>();
            Rigidbodies.Add(R);
        }


    }



}
