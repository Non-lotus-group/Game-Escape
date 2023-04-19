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
    public float attackValue;
    public BoxCollider2D boxCollider1;
    public PolygonCollider2D boxCollider2;

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
        attackValue = 70f;
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

                GameObject instance = Instantiate(SwordLight, SelfPos, SwordRotation);
                SwordAttack swordAttack = instance.GetComponent<SwordAttack>();
                swordAttack.AttackValue = attackValue;
                AttackReady = false;
            }
        }

    }
    void JumpReset()
    {
        if (IsFly == false)
        {
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

    private void OnTriggerEnter2D(Collider2D other)
    { // get the point boxcollider and trigger hit and get normal of this point then set gravity on normal direction 
        if (other.tag == "Wall")
        {
            Vector3 HitPoint = other.ClosestPoint(transform.position);
            HitNormal = (this.transform.position - HitPoint).normalized;
            if (other.IsTouching(boxCollider1))
            {

                IsFly = false;
                float LandAngle = Mathf.Atan2(HitNormal.x, HitNormal.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -LandAngle));
                JumpResetTime = 4f;
            }
            else
            {
                PlayerRigidBody.AddForce(HitNormal * (JumpCount + 1) * 3f, ForceMode2D.Impulse);
                StartCoroutine(StunCoroutine());
            }

        }

    }

    IEnumerator StunCoroutine()
    {
        // 禁用玩家的操控
        HorizontalSpeed = 0f;

        // 等待一秒钟
        yield return new WaitForSeconds(3f);

        // 重新启用玩家的操控
        HorizontalSpeed = 5f;
    }


    void SetGravity()
    {
        Physics.gravity = HitNormal * 10f;
    }

}
