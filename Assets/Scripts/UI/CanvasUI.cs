using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{

    public static CanvasUI instance;
    bool paused;

    CanvasGroup pauseCanvasGroup;
    CanvasGroup settingsCanvasGroup;

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

        pauseCanvasGroup = transform.Find("PauseScreen").GetComponent<CanvasGroup>();
        settingsCanvasGroup = transform.Find("SettingsScreen").GetComponent<CanvasGroup>();



    }

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (paused)
        {
            if (InputManager.instance.PauseKeyDown())
            {
                Resume();
            }
        }
        else
        {
            if (InputManager.instance.PauseKeyDown())
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        Player.instance.EnableActions(false);

        pauseCanvasGroup.alpha = 1f;
        pauseCanvasGroup.interactable = true;
        pauseCanvasGroup.blocksRaycasts = true;

        settingsCanvasGroup.alpha = 0f;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        Player.instance.EnableActions(true);

        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.interactable = false;
        pauseCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0f;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void GoToSettings()
    {
        paused = true;
        Time.timeScale = 0f;
        Player.instance.EnableActions(false);

        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.interactable = false;
        pauseCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 1f;
        settingsCanvasGroup.interactable = true;
        settingsCanvasGroup.blocksRaycasts = true;

    }

}
