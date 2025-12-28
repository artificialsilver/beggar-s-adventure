using UnityEngine;
using System.Collections.Generic;

public class ResultSceneCharacter : MonoBehaviour
{
    // ✨ 아이템 이름과 해당 옷 오브젝트를 연결할 배열 ✨
    [System.Serializable]
    public struct ItemClothesPair
    {
        public string itemName;
        // 옷 이미지(스프라이트 렌더러)가 붙어있는 자식 GameObject
        public GameObject clothesObject; 
    }

    public ItemClothesPair[] availableClothes;
    
    void Start()
    {
        // 1. PlayerController 인스턴스 확인
        if (PlayerController.instance != null)
        {
            // PlayerController의 public 변수 itemCounts에 직접 접근합니다.
            Dictionary<string, int> acquiredItems = PlayerController.instance.itemCounts;
            
            // 2. 옷 입히기 함수 호출
            ApplyClothes(acquiredItems);
        }
        else
        {
            Debug.LogWarning("PlayerController 인스턴스를 찾을 수 없습니다. 아이템 획득 기록을 읽을 수 없습니다.");
        }
    }

    void ApplyClothes(Dictionary<string, int> items)
    {
        // 1. 모든 옷 오브젝트를 초기화 (비활성화)합니다.
        foreach (var clothesPair in availableClothes)
        {
            if (clothesPair.clothesObject != null)
            {
                clothesPair.clothesObject.SetActive(false); 
            }
        }

        // 2. 획득한 아이템을 확인하고 해당 옷 오브젝트를 활성화합니다.
        foreach (var clothesPair in availableClothes)
        {
            // 아이템을 1개 이상 획득했고, 연결된 오브젝트가 있다면
            if (items.ContainsKey(clothesPair.itemName) && items[clothesPair.itemName] > 0)
            {
                if (clothesPair.clothesObject != null)
                {
                    clothesPair.clothesObject.SetActive(true); // 💡 옷 오브젝트 활성화 (레이어 켜기)
                    Debug.Log(clothesPair.itemName + " 아이템을 획득하여 옷을 덧입혔습니다.");
                    
                    // 하나의 옷만 입힐 경우 여기서 break합니다.
                    // **여러 옷을 겹쳐 입히기 위해 이 break;를 제거합니다.** <--- 이 부분을 제거하세요!
                    // break; 
                }
            }
        }
    }
}