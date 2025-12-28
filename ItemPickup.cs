using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // ✨ 이 아이템의 이름 (기록에 사용될 Key) ✨
    // 인스펙터에서 아이템마다 다른 이름을 지정해 줘야 합니다.
    public string itemName; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. 플레이어 컨트롤러 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // 2. 플레이어 스크립트의 PickUpItem 함수 호출
                // 현재 아이템의 이름을 인수로 전달합니다.
                playerController.PickUpItem(itemName); 
            }
            
            // 3. 아이템 오브젝트를 씬에서 파괴
            Destroy(gameObject); 
        }
    }
}