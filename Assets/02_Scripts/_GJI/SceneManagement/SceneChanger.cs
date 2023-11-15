using System.Collections;
using System.Collections.Generic;
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
}
