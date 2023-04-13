using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public BoxCollider2D[] boxColliders;
    public GameObject[] enemyGroup;
    public float GameTime;
    public int BoxNum;
    public int EnemyNum;
    // Start is called before the first frame update
    void Start()
    {
        // 获取当前物体及其所有子物体中所有的BoxCollider
        boxColliders = GetComponents<BoxCollider2D>();

        // 遍历所有BoxCollider
        for (int i = 0; i < boxColliders.Length; i++)
        {
            // 打印BoxCollider的名称
            Debug.Log("BoxCollider Name: " + boxColliders[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        BoxNum = Random.Range(0, boxColliders.Length + 1);
        EnemyNum = Random.Range(0, 2);
    }

    void Timer() {
        GameTime += Time.deltaTime;
    }
    void InstEnemy() {
        if (GameTime < 80f) {

            //InvokeRepeating(enemyGroup[EnemyNum]., 3f, 3f);

        }
    }
}
