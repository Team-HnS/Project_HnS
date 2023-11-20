using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // ������ ������Ʈ���� ������ ����Ʈ
    public List<Transform> spawnPoints; // ���� ��ġ�� ������ ����Ʈ
    public float spawnInterval = 1.0f; // Spawn ����

    public int spawnCount = 10; // �ִ� ȣ�� Ƚ��
    private int currentCount = 0; // ���� ȣ�� Ƚ��


    void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnInterval);
    }

    void SpawnObject()
    {
        // ���� ȣ�� Ƚ���� �ִ� ȣ�� Ƚ���� �����ϸ� �ݺ� ȣ�� ����
        if (currentCount >= spawnCount)
        {
            CancelInvoke("SpawnObject");
            return;
        }

        // �����ϰ� ������Ʈ�� ���� ��ġ�� ����
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // ������Ʈ ����
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        currentCount++;
    }
}
