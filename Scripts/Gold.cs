using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int AddGold;
    // Start is called before the first frame update
    void Start()
    {
        AddGold = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
