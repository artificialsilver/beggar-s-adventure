using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonHandler : MonoBehaviour
{
    // 인스펙터에서 결과 씬의 이름을 입력합니다. (예: "ResultScene")
    public string resultSceneName = "ResultScene"; 

    // 이 함수를 유니티 버튼의 OnClick() 이벤트에 연결합니다.
    public void OnResultButtonClicked()
    {
        // 1. PlayerController 인스턴스에 접근하여 아이템 획득 총 개수를 확인합니다.
        // PlayerController.instance는 이전 단계에서 싱글톤으로 설정했습니다.
        if (PlayerController.instance != null && PlayerController.instance.totalItemsPickedUp >= 0)
        {
            Debug.Log("아이템을 " + PlayerController.instance.totalItemsPickedUp + "개 획득했습니다. 결과 씬으로 이동합니다.");
            
            // 2. 조건 충족 시 다음 씬 로드
            SceneManager.LoadScene(resultSceneName);
        }
        else
        {
            Debug.Log("error");
            // (선택 사항) 여기에 "아이템을 먼저 획득하세요"와 같은 UI 팝업 메시지 출력 로직을 추가할 수 있습니다.
        }
    }
}