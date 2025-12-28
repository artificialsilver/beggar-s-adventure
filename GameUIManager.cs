using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    // 메인 메뉴로 이동
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;   
        if (PlayerController.instance != null)
        {
            PlayerController.instance.ResetItems();
        }
        SceneManager.LoadScene("start");    }

    // 게임 종료
    public void QuitGame()
    {
        Debug.Log("게임 종료"); // 에디터 확인용
        Application.Quit();
    }
}
