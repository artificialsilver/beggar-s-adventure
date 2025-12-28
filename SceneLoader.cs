using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능을 사용하기 위해 필요합니다!

public class SceneLoader : MonoBehaviour
{
    // 이 함수가 버튼 클릭 이벤트에 연결될 함수입니다.
    public void LoadNextScene(string sceneName)
    {
        // SceneManager를 사용하여 지정된 이름의 씬을 로드합니다.
        SceneManager.LoadScene(sceneName);
    }

    // 다음 씬의 빌드 인덱스를 사용하고 싶다면 이렇게 할 수도 있습니다.
    public void LoadNextSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}