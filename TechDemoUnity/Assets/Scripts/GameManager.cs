using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("InThePark");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
   
}
