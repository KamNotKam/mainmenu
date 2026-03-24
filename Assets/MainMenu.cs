using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject playPanel;
    public GameObject continuePanel;
    public GameObject settingsPanel;

    public TextMeshProUGUI titleText;

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        playPanel.SetActive(true);
        titleText.text = "PLAY";
    }

    public void OpenContinue()
    {
        mainMenuPanel.SetActive(false);
        continuePanel.SetActive(true);
        titleText.text = "CONTINUE";
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        titleText.text = "SETTINGS";
    }

    public void BackToMenu()
    {
        playPanel.SetActive(false);
        continuePanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        titleText.text = "MAIN MENU";
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Keluar");
    }
}