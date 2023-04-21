using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkEnemyFar : EnemyBase
{
    GameObject Instant;
    public Quaternion BulletRotation;
    public float ShootAngle;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnBullet());
        MaxHealth = 100f;
        Health = 100f;
        HealthSlider = GetComponentInChildren<Slider>();
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            Vector2 ShootDir = (Player.transform.position - transform.position).normalized;
            ShootAngle = Mathf.Atan2(ShootDir.y, ShootDir.x) * Mathf.Rad2Deg;
            BulletRotation = Quaternion.AngleAxis(ShootAngle, Vector3.forward);
            Instantiate(Bullet, transform.position, BulletRotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
