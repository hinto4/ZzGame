using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log("Attempting to load " + SceneName);
    }
}
