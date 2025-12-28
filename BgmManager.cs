using UnityEngine;

public class BgmManager : MonoBehaviour
{
    // 정적(static) 변수로 이 스크립트의 인스턴스를 저장하여
    // 어디서든 접근할 수 있게 하고, 중복 생성을 막습니다.
    public static BgmManager instance;

    void Awake()
    {
        // 1. 인스턴스 확인 (Singleton 패턴)
        if (instance == null)
        {
            // 아직 인스턴스가 없으면, 이 오브젝트를 인스턴스로 설정합니다.
            instance = this;
            
            // 2. 씬이 로드될 때 파괴되지 않도록 설정
            // 이 설정 덕분에 씬이 바뀌어도 이 오브젝트와 그 AudioSource가 유지됩니다.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 이미 다른 인스턴스가 존재한다면, 새로 생성된 이 오브젝트는 파괴합니다.
            // 이렇게 함으로써 BGM이 중복으로 재생되는 것을 방지합니다.
            Destroy(gameObject);
        }
    }

    // (선택 사항) BGM을 재생하는 메서드를 추가할 수도 있습니다.
    // void Start()
    // {
    //     // 이 오브젝트에 AudioSource 컴포넌트가 있다면 여기서 재생을 시작할 수 있습니다.
    //     if (GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying)
    //     {
    //         GetComponent<AudioSource>().Play();
    //     }
    // }
}