using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    private Transform mChild;
    void Start()
    {
        mChild = gameObject.transform.Find("coin_b");
    }
    
    void Update()
    {
        mChild.Rotate(new Vector3(Random.Range(1, 4), 0, Random.Range(1, 4)));
    }
}
