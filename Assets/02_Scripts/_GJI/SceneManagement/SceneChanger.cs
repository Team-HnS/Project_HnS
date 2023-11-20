using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Map_Town 1_master");
    }

    public void TutorialTownNpc()
    {
        SceneManager.LoadScene("Map_BattleRoyal _master");
    }

    public void StartSceneLoading()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void StartSceneLoading1()
    {
        SceneManager.LoadScene("LoadingScene1");
    }
    public void StartSceneLoading2()
    {
        SceneManager.LoadScene("LoadingScene2");
    }
    public void StartSceneLoading3()
    {
        SceneManager.LoadScene("LoadingScene3");
    }
    public void StartSceneLoading4()
    {
        SceneManager.LoadScene("LoadingScene4");
    }

    public void instanceDeongun()
    {
        SceneManager.LoadScene("Map_InstanceDungeon_master");
    }
}
