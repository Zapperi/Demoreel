using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// TestScene1 Button script to return to Main Menu.
/// </summary>
public class TestScene1BackButton : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneLoader.Instance.UnloadSceneByIndex(gameObject.scene.buildIndex);
    }
}
