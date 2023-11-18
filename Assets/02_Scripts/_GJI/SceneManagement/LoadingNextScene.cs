using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // 비디오 관련 기능을 사용하기 위한 네임스페이스 추가
using System.Collections;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TMP_Text loadingText;
    public VideoPlayer videoPlayer; // 비디오 플레이어 참조를 위한 변수 추가

    void Start()
    {
        StartCoroutine(AsyncNextScene(sceneNumber));
    }

    IEnumerator AsyncNextScene(int num)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(num);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            loadingSlider.value = asyncOperation.progress;
            loadingText.text = (asyncOperation.progress * 100).ToString() + "%";

            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            // 비디오 플레이어가 있는지 확인 후 동기화
            if (videoPlayer != null)
            {
                // 로딩 진행률과 비디오 재생 진행률을 동기화하여 표시
                videoPlayer.time = asyncOperation.progress * videoPlayer.clip.length;
            }

            yield return null;
        }
    }
}
