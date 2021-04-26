using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public GameObject instruction;
    public GameObject Back;
    public void instructionGame()
    {
        instruction.SetActive(true);
    }
    public void BackBtn()
    {
        instruction.SetActive(false);
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame ()
    {
        Application.Quit();
    } 
}
