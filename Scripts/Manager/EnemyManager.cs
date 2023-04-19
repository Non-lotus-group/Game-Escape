using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public BoxCollider2D[] boxColliders;
    public GameObject[] enemyGroup;
    public float GameTime;
    public int BoxNum;
    public int EnemyNum;
    public GameObject Player;
    public float SpawnTime;
    //public int PoolSize = 10;
    //private ObjectPool<GameObject>[] enemyPools;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        // 获取当前物体及其所有子物体中所有的BoxCollider
        boxColliders = GetComponents<BoxCollider2D>();
        //enemyPools = new ObjectPool<GameObject>[enemyGroup.Length];
        //for (int i = 0; i < enemyGroup.Length; i++)
        //{
        //    enemyPools[i] = new ObjectPool<GameObject>(enemyGroup[i]);
        //}
        SpawnTime = 2f;
        StartCoroutine(SpawnEnemies());


    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        BoxNum = Random.Range(0, boxColliders.Length);
        EnemyNum = Random.Range(0, 2);

    }

    void Timer()
    {
        GameTime += Time.deltaTime;
    }
    Vector2 GetSpawnPoint()
    {
        Vector2 ZoneSize = boxColliders[BoxNum].size;
        Vector2 zonePosition = boxColliders[BoxNum].transform.TransformPoint(boxColliders[BoxNum].offset);
        Vector2 spawnPosition = new Vector2(Random.Range(zonePosition.x - ZoneSize.x / 2f, zonePosition.x + ZoneSize.x / 2f),
            Random.Range(zonePosition.y - ZoneSize.y / 2f, zonePosition.y + ZoneSize.y / 2f));
        return spawnPosition;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            //GameObject Enemy = enemyPool.GetObject();
            Vector2 spawnPosition;
            do
            {
                spawnPosition = GetSpawnPoint();
            } while (Vector2.Distance(spawnPosition, Player.transform.position) < 5f);
            Instantiate(enemyGroup[EnemyNum], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
