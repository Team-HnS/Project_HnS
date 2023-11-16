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

    public void instanceDeongun()
    {
        SceneManager.LoadScene("Map_InstanceDungeon_master");
    }
}
