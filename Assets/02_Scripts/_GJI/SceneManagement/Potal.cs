using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using GameDevTV.Saving;
using RPG.SceneManagement;

// 씬 간 이동을 담당하는 포털 클래스
public class Portal : MonoBehaviour
{
    // 이동할 씬의 인덱스
    [SerializeField] int sceneToLoad = -1;

    // 이동 후의 스폰 지점
    [SerializeField] Transform spawnPoint;

    // 목적지 식별자 열거형
    enum DestinationIdentifier
    {
        A, B, C, D, E
    }

    // 포털의 목적지 식별자
    [SerializeField] DestinationIdentifier destination;

    // 페이드 아웃 시간
    [SerializeField] float fadeOutTime = 1f;

    // 페이드 인 시간
    [SerializeField] float fadeInTime = 2f;

    // 페이드 대기 시간
    [SerializeField] float fadeWaitTime = 0.5f;

    // 플레이어가 트리거에 진입했을 때 호출되는 메소드
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    // 이동 및 전환을 처리하는 코루틴 메소드
    private IEnumerator Transition()
    {
        // 이동할 씬이 설정되지 않은 경우 에러 출력 후 종료
        if (sceneToLoad < 0)
        {
            Debug.LogError("Scene to load not set.");
            yield break;
        }

        // 포털 게임 오브젝트를 씬 전환 후에 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);

        // Fader, SavingWrapper, PlayerController 등 필요한 컴포넌트들을 찾아옴
        Fader fader = FindObjectOfType<Fader>();
        SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
        PlayerMovement playerController = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerController.enabled = false;

        // 페이드 아웃 수행
        yield return fader.FadeOut(fadeOutTime);

        // 현재 상태 저장
        savingWrapper.Save();

        // 씬을 비동기적으로 로드
        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        // 새로운 플레이어 컨트롤러 가져오기
        PlayerMovement newPlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        newPlayerController.enabled = false;

        // 저장된 상태 불러오기
        savingWrapper.Load();

        // 이동할 포털 찾기
        Portal otherPortal = GetOtherPortal();

        // 플레이어 위치 및 상태 업데이트
        UpdatePlayer(otherPortal);

        // 상태 재저장
        savingWrapper.Save();

        // 페이드 대기 시간만큼 대기 후 페이드 인 수행
        yield return new WaitForSeconds(fadeWaitTime);
        fader.FadeIn(fadeInTime);

        // 새로운 플레이어 컨트롤러 활성화 및 현재 포털 파괴
        newPlayerController.enabled = true;
        Destroy(gameObject);
    }

    // 플레이어 업데이트를 위한 메소드
    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindWithTag("Player");

        // 네비게이션 매쉬 에이전트 비활성화 후 위치 및 회전 설정
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.transform.position = otherPortal.spawnPoint.position;
        player.transform.rotation = otherPortal.spawnPoint.rotation;
        player.GetComponent<NavMeshAgent>().enabled = true;
    }

    // 다른 포털 찾기 위한 메소드
    private Portal GetOtherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;
            if (portal.destination != destination) continue;

            return portal;
        }

        return null;
    }
}

