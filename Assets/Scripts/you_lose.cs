using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class you_lose : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("pls");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
