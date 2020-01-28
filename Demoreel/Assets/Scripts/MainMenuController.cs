using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;
    public Canvas mainMenuCanvas;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        SceneLoader.Instance.LoadTestScene();
    }

    public void HideMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
    }
}
