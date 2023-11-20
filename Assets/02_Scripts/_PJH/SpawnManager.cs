using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // 스폰할 오브젝트들을 저장할 리스트
    public List<Transform> spawnPoints; // 스폰 위치를 저장할 리스트
    public float spawnInterval = 1.0f; // Spawn 간격

    public int spawnCount = 10; // 최대 호출 횟수
    private int currentCount = 0; // 현재 호출 횟수


    void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnInterval);
    }

    void SpawnObject()
    {
        // 현재 호출 횟수가 최대 호출 횟수에 도달하면 반복 호출 중지
        if (currentCount >= spawnCount)
        {
            CancelInvoke("SpawnObject");
            return;
        }

        // 랜덤하게 오브젝트와 스폰 위치를 선택
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // 오브젝트 스폰
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        currentCount++;
    }
}
