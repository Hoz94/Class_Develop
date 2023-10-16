using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public PoolingManager poolingManager;
    public Transform[] spawnPoints; // 몬스터를 스폰할 위치 배열
    public float spawnInterval = 1f; // 몬스터 스폰 간격

    private float spawnTimer = 1f;

    void Update()
    {
        // 일정 간격으로 몬스터 스폰
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnMonster();
            spawnTimer = 0f;
        }
    }

    void SpawnMonster()
    {
        // 스폰 포인트 중 하나를 랜덤으로 선택
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // 오브젝트 풀에서 비활성화된 몬스터를 가져옴
        GameObject monster = poolingManager.GetEnemies();

        if (monster != null)
        {
            // 가져온 몬스터를 스폰 포인트 위치로 이동하고 활성화
            monster.transform.position = spawnPoint.position;
            monster.transform.rotation = spawnPoint.rotation;
            monster.SetActive(true);
        }
    }

}
