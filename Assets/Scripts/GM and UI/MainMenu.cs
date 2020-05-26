using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        FindObjectOfType<AudioManager>().Stop("Menu Music");
        FindObjectOfType<AudioManager>().Play("Background Music");
        SceneManager.LoadScene("lvl1");
    }

    public void PlayLevel2()
    {
        FindObjectOfType<AudioManager>().Stop("Menu Music");
        FindObjectOfType<AudioManager>().Play("Background Music2");
        SceneManager.LoadScene("lvl2");
    }

    public void PlayLevel3()
    {
        FindObjectOfType<AudioManager>().Stop("Menu Music");
        SceneManager.LoadScene("TestScene");
    }

    public void Options()
    {
        Debug.Log("Options menu here");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
