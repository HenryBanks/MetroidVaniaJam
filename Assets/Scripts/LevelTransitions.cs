﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransitions : MonoBehaviour
{
    public static LevelTransitions instance;

    int positionIndex=0;

    CanvasGroup transitionScreen;

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
            //LoadLevelWithPosition(1, 1);
            StartCoroutine(FadeOut(50));
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
        TransitionScreen.instance.canvasGroup.alpha = 1f;
        StartCoroutine(FadeIn(50));
    }

    public void LoadLevelWithPosition(int sceneIndex, int posIndex)
    {
        positionIndex = posIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator FadeIn(int steps)
    {
        for (int f = 0; f <= steps; f++)
        {
            TransitionScreen.instance.canvasGroup.alpha -= 1f / steps;
            yield return null;
        }
    }

    IEnumerator FadeOut(int steps)
    {
        for (int f = 0; f <= steps; f++)
        {
            TransitionScreen.instance.canvasGroup.alpha += 1f / steps;
            yield return null;
        }
        LoadLevelWithPosition(1, 1);

    }

}
