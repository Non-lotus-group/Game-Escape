using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.GetChild(0).name);
        Debug.Log(transform.GetChild(1).name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
