using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public BoxCollider2D[] boxColliders;
    public GameObject[] collisionGroup;
    public float GameTime;
    public int BoxNum;
    public int collisionNum;
    public float SpawnTime;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        boxColliders = GetComponents<BoxCollider2D>();
        SpawnTime = 2f;
        StartCoroutine(SpawnCollisions());
    }

    // Update is called once per frame
    void Update()
    {
        BoxNum = Random.Range(0, boxColliders.Length);
        collisionNum = Random.Range(0, 2);
    }
    Vector2 GetSpawnPoint()
    {
        Vector2 ZoneSize = boxColliders[BoxNum].size;
        Vector2 zonePosition = boxColliders[BoxNum].transform.TransformPoint(boxColliders[BoxNum].offset);
        Vector2 spawnPosition = new Vector2(Random.Range(zonePosition.x - ZoneSize.x / 2f, zonePosition.x + ZoneSize.x / 2f),
            Random.Range(zonePosition.y - ZoneSize.y / 2f, zonePosition.y + ZoneSize.y / 2f));
        return spawnPosition;
    }
    IEnumerator SpawnCollisions()
    {
        while (true)
        {
            //GameObject Enemy = enemyPool.GetObject();
            Vector2 spawnPosition;
            do
            {
                spawnPosition = GetSpawnPoint();
            } while (Vector2.Distance(spawnPosition, Player.transform.position) < 5f);
            Instantiate(collisionGroup[collisionNum], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
