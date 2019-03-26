using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    bool paused;

    CanvasGroup pauseCanvasGroup;
    CanvasGroup settingsCanvasGroup;

    // Start is called before the first frame update
    void Awake()
    {
        pauseCanvasGroup = GetComponent<CanvasGroup>();
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
        pauseCanvasGroup.alpha = 1f;
        pauseCanvasGroup.interactable = true;
        Player.instance.EnableActions(false);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.interactable = false;
        Player.instance.EnableActions(true);
    }

    public void GoToSettings()
    {
        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.interactable = false;
        Player.instance.EnableActions(true);

    }
}
