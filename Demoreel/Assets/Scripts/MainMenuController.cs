using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls MainMenu canvas and it's actions.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// Singleton of MainMenuController class, use this to access Main Menu actions.
    /// </summary>
    public static MainMenuController Instance;
    /// <summary>
    /// Reference to the Main Menu Canvas.
    /// </summary>
    [Tooltip("Reference to the Main Menu Canvas.")]
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

    #region ---Public Functions---

    /// <summary>
    /// Placeholder, currently loads only Test Scene.
    /// </summary>
    public void LoadNextLevel()
    {
        SceneLoader.Instance.LoadTestScene(1);
    }

    /// <summary>
    /// Hides Main Menu gameobject by deactivating it.
    /// </summary>
    public void HideMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows Main Menu gameobject by enabling it.
    /// </summary>
    public void ShowMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(true);
    }

    #endregion
}
