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
    public Vector3 PointPos;
    public float JumpAlgle;
    public bool AttackReady;
    public float CoolDownCount;
    public GameObject SwordLight;
    public float attackValue;
    // Start is called before the first frame update
    void Start()
    {
        CoolDownCount = 6;
        GameTime = 6;
        attackValue = 120;
        AttackReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        Blink();
        GeTsuGA();
        GetMousePos();
    }
    void Blink()
    {
        if (GameTime > cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameTime = 0;
                if (Distance < 50f)
                {
                    this.transform.position = PointPos;
                }
                else
                {
                    this.transform.position -= JumpDir;
                }
            }
        }
        else
        {
            GameTime += Time.deltaTime;
        }

    }
    void GeTsuGA()
    {
        Quaternion SwordRotation = Quaternion.AngleAxis(JumpAlgle, Vector3.forward);
        if (AttackReady == false)
        {
            CoolDownCount -= Time.deltaTime;
            if (CoolDownCount < 0)
            {
                AttackReady = true;
                CoolDownCount = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (AttackReady == true)
            {

                GameObject instance = Instantiate(SwordLight, SelfPos, SwordRotation);
                instance.transform.localScale = new Vector3(4, 4, 4);
                SwordAttack swordAttack = instance.GetComponent<SwordAttack>();
                swordAttack.AttackValue = attackValue;
                AttackReady = false;
            }
        }
    }

    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PointPos = new Vector3(MousePos.x, MousePos.y, 0);
        SelfPos = this.transform.position;
        JumpDir = (MousePos - SelfPos).normalized;
        Distance = Vector3.Distance(SelfPos, MousePos);
        JumpAlgle = Mathf.Atan2(MousePos.y - SelfPos.y, MousePos.x - SelfPos.x) * Mathf.Rad2Deg;
    }
}


