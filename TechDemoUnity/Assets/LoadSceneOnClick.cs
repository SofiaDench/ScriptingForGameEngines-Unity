using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene(string sceneName);
    {
    SceneManager.LoadScene(sceneName);
    }
}