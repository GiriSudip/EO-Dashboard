using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Loading;
    public ActionScriptableObject[] actions;


    private void Update()
    {
    }

    public void ShowUI(GameObject UI)
    {
        UI.SetActive(true);
    }

 public void HideUI(GameObject UI)
    {
        UI.SetActive(false);
    }

    public void SceneChange(int SceneIndex)
    {
        Loading.SetActive(true);
        SceneManager.LoadSceneAsync(SceneIndex);
        if(!Reference.canMove)
        {
            Reference.canMove = true;
        }

        Time.timeScale = 1;
        foreach (ActionScriptableObject a in actions)
        {
            a.ResetDefault();
        }
        Reference.ResetDefault();
    }

    public void QuitGame()
    {
        foreach (ActionScriptableObject a in actions)
        {
            a.ResetDefault();
        }
        Reference.ResetDefault();
        Application.Quit();
    }
    
    public void OpenPdf(string name)
    {
     Application.OpenURL(System.Environment.CurrentDirectory+"/"+name);
    }

    public void ButtonSound(AudioSource sound)
    {
        sound.Play();
    }
}
