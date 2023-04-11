using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    public bool AbleJump;
    public float HorizontalSpeed;
    public Vector2 JumpDir;
    public Vector2 MousePos;
    public Vector2 SelfPos;
    public float JumpAlgle;
    public int JumpCount;
    public float JumpResetTime;
    public float HorizontalSpeedItemPromote;
    public GameObject SwordLight;
    public float CoolDownCount;
    public bool AttackReady;
    public bool IsFly;
    public Vector2 HitNormal;

    private void Awake()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        AbleJump = false;
        JumpResetTime = 4;
        JumpCount = 0;
        HorizontalSpeed = 5f;
        HorizontalSpeedItemPromote = 1;
        CoolDownCount = 2;
        AttackReady = true;
        IsFly = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        GetMousePos();
        Attack();
        Jump();
        JumpReset();
        JumpRotate();
        Debug.Log(JumpCount);
        SetGravity();
    }


    void MoveHorizontal()
    {
        if (IsFly == false)
        {
            Vector3 playerXDirection = transform.TransformDirection(Vector3.right);
            Vector3 playerXNormal = new Vector3(playerXDirection.x, playerXDirection.y, 0f).normalized;
            PlayerRigidBody.velocity = Input.GetAxis("Horizontal") * HorizontalSpeed * playerXNormal;
        }
    }
    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SelfPos = this.transform.position;
        JumpDir = (MousePos - SelfPos).normalized;
        JumpAlgle = Mathf.Atan2(MousePos.y - SelfPos.y, MousePos.x - SelfPos.x) * Mathf.Rad2Deg;
    }
    void Jump()
    {
        if (IsFly == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRigidBody.AddForce(JumpDir * 5f * (JumpCount + 1), ForceMode2D.Impulse);//后期换成曲线涨幅？
                IsFly = true;
                PlayerRigidBody.gravityScale = 0;
                JumpCount++;
                Debug.Log(JumpCount);
            }
        }


    }
    void Attack()
    {//实例化swordLight
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (AttackReady == true)
            {
                Instantiate(SwordLight, SelfPos, SwordRotation);
                AttackReady = false;
            }
        }

    }
    void JumpReset()
    {
        if (IsFly == false) {
            if (JumpResetTime > 0)
            {
                JumpResetTime -= Time.deltaTime;
            }
            else
            {
                JumpCount = 0;
                JumpResetTime = 4;
            }
        }
           
    }
    void JumpRotate()
    {
        if (IsFly == true)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, JumpAlgle - 90));
        }

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Wall")
        {
            Vector3 HitPoint = collider2D.ClosestPoint(transform.position);
            HitNormal = (this.transform.position - HitPoint).normalized;
            IsFly = false;
            float LandAngle = Mathf.Atan2(HitNormal.x, HitNormal.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -LandAngle));
            JumpResetTime = 4f;
        }

    }

    void SetGravity()
    {
        Physics.gravity = HitNormal * 10f;
    }

}
