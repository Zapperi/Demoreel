using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles scene loading and closing. Plays scene transistion animation between changes.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Singleton of the SceneLoader class, use this is access the class.
    /// </summary>
    public static SceneLoader Instance;
    /// <summary>
    /// Reference to the scene transistion animation animator.
    /// </summary>
    [Tooltip("Reference to the scene transistion animation animator.")]
    public Animator sceneLoaderAnimator;
    /// <summary>
    /// How many transistions there are in total.
    /// </summary>
    [Tooltip("How many transistions there are in total.")]
    public int transistionCount = 3; // Needs to be reworked to be dynamic.
    /// <summary>
    /// Forces the scene transistion animator to play a spesific animation.
    /// </summary>
    [SerializeField]
    [Tooltip("Forces the scene transistion animator to play a spesific animation.")]
    private bool _forceMode = false;
    /// <summary>
    /// Which animation is forced.
    /// </summary>
    [SerializeField]
    [Tooltip("Which animation is forced.")]
    private int _forcedTransistion = 1; // Needs to be reworked into enum.

    /// <summary>
    /// How long transistion animation holds black screen.
    /// </summary>
    [SerializeField]
    [Tooltip("How long transistion animation holds black screen.")]
    private float _transistionTime = 2;


    public void Start()
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

#region ---PUBLIC FUNCTIONS---

    /// <summary>
    /// Loads spesific TestScene with index. "TestScene_" + number.
    /// </summary>
    /// <param name="testSceneIndex">Index of the test scene to load.</param>
    public void LoadTestScene(int testSceneIndex)
    {
        if(testSceneIndex < 1)
        {
            Debug.LogWarning("TRYING TO LOAD TESTSCENE INDEX UNDER 1!");
        }
        StartCoroutine(LoadScene("TestScene_"+testSceneIndex));
    }

    /// <summary>
    /// Unloads spesific active scene by given build index.
    /// </summary>
    /// <param name="buildIndex">Build index of the scene to unload.</param>
    public void UnloadSceneByIndex(int buildIndex)
    {
        StartCoroutine(UnloadScene(buildIndex));
    }

    #endregion
    #region ---PRIVATE FUNCTIONS---

    /// <summary>
    /// Loads a scene by name. Activates random scene transistion animation in between.
    /// </summary>
    /// <param name="sceneName">Scene to load.</param>
    /// <returns></returns>
    private IEnumerator LoadScene(string sceneName)
    {
        int transistionNumber;
        // If forced animation mode is activated, uses given animation. Otherwise randomize the animation. 
        if (_forceMode)
        {
            transistionNumber = _forcedTransistion;
        }
        else
        {
            transistionNumber = Random.Range(1, transistionCount);
        }
        // Activate transistion "ToBlack" animation.
        sceneLoaderAnimator.SetTrigger("EndScene" + transistionNumber);
        yield return new WaitForSeconds(_transistionTime/2);
        // While screen is black, hide Main Menu.
        MainMenuController.Instance.HideMainMenu();
        // Load a new scene while screen is black.
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(_transistionTime / 2);
        // Fade back to game.
        sceneLoaderAnimator.SetTrigger("StartScene" + transistionNumber);
    }

    /// <summary>
    /// Unloads spesific scene by it's build index. Activates transistion animation in between.
    /// </summary>
    /// <param name="buildIndex">Build index of the scene to unload.</param>
    /// <returns></returns>
    private IEnumerator UnloadScene(int buildIndex)
    {
        int transistionNumber;
        // If forced animation mode is activated, uses given animation. Otherwise randomize the animation. 
        if (_forceMode)
        {
            transistionNumber = _forcedTransistion;
        }
        else
        {
            transistionNumber = Random.Range(1, transistionCount);
        }
        // Activate transistion "ToBlack" animation.
        sceneLoaderAnimator.SetTrigger("EndScene" + transistionNumber);
        yield return new WaitForSeconds(_transistionTime / 2);
        // While screen is black, show Main Menu.
        MainMenuController.Instance.ShowMainMenu();
        SceneManager.UnloadSceneAsync(buildIndex);
        yield return new WaitForSeconds(_transistionTime / 2);
        // Fade back to game.
        sceneLoaderAnimator.SetTrigger("StartScene" + transistionNumber);
    }
    #endregion
}
