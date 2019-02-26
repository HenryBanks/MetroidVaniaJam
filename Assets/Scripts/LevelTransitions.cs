using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    public static LevelTransitions instance;

    int positionIndex=0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadLevelWithPosition(1, 1);
        }
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    Debug.Log("Level Loaded");
    //    Debug.Log(SpawnPositions.instance.spawnPositionsList[positionIndex]);
    //    Player.instance.transform.position=SpawnPositions.instance.spawnPositionsList[positionIndex];
    //    Debug.Log(Player.instance.transform.position);
    //}

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded");
        Debug.Log(SpawnPositions.instance.spawnPositionsList[positionIndex]);
        Player.instance.transform.position = SpawnPositions.instance.spawnPositionsList[positionIndex];
        Debug.Log(Player.instance.transform.position);
    }

    public void LoadLevelWithPosition(int sceneIndex, int posIndex)
    {
        positionIndex = posIndex;
        SceneManager.LoadScene(sceneIndex);

    }

}
