using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    public Animator sceneLoaderAnimator;
    [SerializeField]
    private float m_transistionTime;
    public int transistionCount = 3;

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

    public void LoadTestScene()
    {
        StartCoroutine(LoadScene("TestScene_1"));
    }

    public void UnloadSceneByIndex(int buildIndex)
    {
        StartCoroutine(UnloadScene(buildIndex));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        int transistionNumber = Random.Range(1, transistionCount);
        sceneLoaderAnimator.SetTrigger("EndScene"+ transistionNumber);
        yield return new WaitForSeconds(m_transistionTime);
        MainMenuController.Instance.HideMainMenu();
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        sceneLoaderAnimator.SetTrigger("StartScene"+ transistionNumber);
    }

    private IEnumerator UnloadScene(int buildIndex)
    {
        int transistionNumer = Random.Range(1, transistionCount);
        sceneLoaderAnimator.SetTrigger("EndScene" + transistionNumer);
        yield return new WaitForSeconds(m_transistionTime);
        MainMenuController.Instance.ShowMainMenu();
        SceneManager.UnloadSceneAsync(buildIndex);
        sceneLoaderAnimator.SetTrigger("StartScene" + transistionNumer);
    }
}
