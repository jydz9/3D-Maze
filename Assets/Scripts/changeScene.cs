using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(2);
    }
    public void aboutScreen()
    {
        SceneManager.LoadScene(1);
    }
    public void backtoMain()
    {
        SceneManager.LoadScene(0);
    }
}
