using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    public GameObject player;
    public Player player_s;
    public PlayerMovement player_m;

    public bool OnUiInteraction = false;

    public GameObject reviveZone;

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<Player>().gameObject;
        player_s = player.GetComponent<Player>();
        player_m = player.GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        reviveZone = GameObject.Find("ReviveZone");


    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        reviveZone = GameObject.Find("ReviveZone");

        player = FindObjectOfType<Player>().gameObject;
        player_s = player.GetComponent<Player>();
        player_m = player.GetComponent<PlayerMovement>();
    }

    public void PlayerRevive()
    {
        player.transform.position = reviveZone.transform.position;
        player_m.playerCharacter.rotation = reviveZone.transform.rotation;
        player_s.GetComponent<NavMeshAgent>().enabled = true;
        player_s.PlayerRevival();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
