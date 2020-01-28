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
    private int transistionCount = 2;

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


        sceneLoaderAnimator.SetTrigger("StartScene1");
    }

    public void LoadTestScene()
    {
        StartCoroutine(LoadScene("TestScene_1"));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        //int transistionNumer = Random.Range(1, transistionCount);
        int transistionNumer = 2;
        sceneLoaderAnimator.SetTrigger("EndScene"+ transistionNumer);
        yield return new WaitForSeconds(m_transistionTime);
        MainMenuController.Instance.HideMainMenu();
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        sceneLoaderAnimator.SetTrigger("StartScene"+ transistionNumer);
    } 
}
