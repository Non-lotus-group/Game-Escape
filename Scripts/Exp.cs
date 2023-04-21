using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float AddExp;
    // Start is called before the first frame update
    void Start()
    {
        AddExp = Random.Range(1, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
