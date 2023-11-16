using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalMove : MonoBehaviour
{
    public string sceneToLoad; // 이동할 씬의 이름

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 활성!!");
        // 만약 콜라이더에 충돌한 객체가 플레이어라면
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 닿았!");
            // sceneToLoad에 지정된 씬으로 이동
            Debug.Log("이동!");
            SceneManager.LoadScene("Map_Town 1_master");
        }
    }
}
