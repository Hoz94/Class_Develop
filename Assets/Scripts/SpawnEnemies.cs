using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public PoolingManager poolingManager;
    public Transform[] spawnPoints; // ���͸� ������ ��ġ �迭
    public float spawnInterval = 1f; // ���� ���� ����

    private float spawnTimer = 1f;

    void Update()
    {
        // ���� �������� ���� ����
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnMonster();
            spawnTimer = 0f;
        }
    }

    void SpawnMonster()
    {
        // ���� ����Ʈ �� �ϳ��� �������� ����
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // ������Ʈ Ǯ���� ��Ȱ��ȭ�� ���͸� ������
        GameObject monster = poolingManager.GetEnemies();

        if (monster != null)
        {
            // ������ ���͸� ���� ����Ʈ ��ġ�� �̵��ϰ� Ȱ��ȭ
            monster.transform.position = spawnPoint.position;
            monster.transform.rotation = spawnPoint.rotation;
            monster.SetActive(true);
        }
    }

}
