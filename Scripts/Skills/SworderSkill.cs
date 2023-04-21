using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SworderSkill : MonoBehaviour
{
    public Vector3 MousePos;
    public Vector3 SelfPos;
    public float Distance;
    public float cooldownTime = 2.0f;
    public float GameTime;
    public Vector3 JumpDir;
    // Start is called before the first frame update
    void Start()
    {
        GameTime = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Blink();
        GetMousePos();
    }
    void Blink() {
        if (GameTime > cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameTime = 0;
                if (Distance < 10f)
                {
                    this.transform.position = MousePos;
                }
                else
                {
                    this.transform.position += JumpDir;
                }
            }
        }
        else {
            GameTime += Time.deltaTime;
        }
       
    }
    void GeTsuGA() { }

    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SelfPos = this.transform.position;
        JumpDir = (MousePos - SelfPos).normalized;
        Distance = Vector3.Distance(SelfPos, MousePos);
    }
}


