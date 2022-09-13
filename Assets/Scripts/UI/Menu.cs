using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel?.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OnButton(GameObject button)
    {
            button?.SetActive(true);
    }

    public void OffButton(GameObject button)
    {
            button?.SetActive(false);
    }

}
