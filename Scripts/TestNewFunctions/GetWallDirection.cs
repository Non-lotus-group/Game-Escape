using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWallDirection : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    public Vector2 JumpDir;
    public Vector2 MousePos;
    public Vector2 SelfPos;
    public float JumpAlgle;
    public bool IsFly;
    public Vector2 HitNormal;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        IsFly = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        Jump();
        JumpRotate();


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigidBody.AddForce(JumpDir * 6f, ForceMode2D.Impulse);//后期换成曲线涨幅？
            PlayerRigidBody.gravityScale = 0;
            IsFly = true;
        }
    }
    void JumpRotate()
    {
        if (IsFly == true)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, JumpAlgle - 90));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Vector3 HitPoint = collision.ClosestPoint(transform.position);
        HitNormal = (this.transform.position - HitPoint).normalized;
        Debug.Log(this.transform.position);
        Debug.Log(HitPoint);
        float LandAngle = Mathf.Atan2(HitNormal.x, HitNormal.y) * Mathf.Rad2Deg;
        IsFly = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -LandAngle));
    }

    void SetGravity()
    {
        Physics.gravity = HitNormal * 100f;
    }
}
