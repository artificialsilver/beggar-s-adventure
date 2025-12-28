using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // 1. 인스펙터에 연결할 아이템 프리팹 리스트 (3개)
    public GameObject[] itemPrefabs;

    // 2. 인스펙터에 연결할 스폰 위치 Transform 리스트 (3개)
    public Transform[] spawnPoints; 

    // 테스트용: 게임 시작 시 한 번 랜덤 아이템을 생성합니다.
    void Start()
    {
        // 🚨 스폰 기능을 테스트하고 싶다면 이 주석을 해제하세요. 🚨
        SpawnRandomItem(); 
    }
    
    // 아이템을 랜덤으로 선택하고, 랜덤 위치에 생성하는 함수
    public void SpawnRandomItem()
    {
        // 리스트가 비어있으면 생성 불가
        if (itemPrefabs.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogError("스포너 설정 오류: 아이템 프리팹 또는 스폰 위치 리스트를 확인해 주세요!");
            return;
        }

        // --- 아이템 선택 ---
        // 0부터 '리스트 길이 - 1'까지의 무작위 인덱스 생성
        int randomItemIndex = Random.Range(0, itemPrefabs.Length);
        GameObject selectedItem = itemPrefabs[randomItemIndex];

        // --- 위치 선택 ---
        int randomPositionIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomPositionIndex];
        
        // --- 아이템 생성 ---
        Instantiate(selectedItem, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

        Debug.Log("아이템 '" + selectedItem.name + "'이 위치 #" + (randomPositionIndex + 1) + "에 생성되었습니다.");
    }
}