using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene1BackButton : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneLoader.Instance.UnloadSceneByIndex(gameObject.scene.buildIndex);
    }
}
