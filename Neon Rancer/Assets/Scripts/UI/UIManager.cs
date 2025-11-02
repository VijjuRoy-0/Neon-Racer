using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private TriggerChecker checker;
    public GameObject menuPanel;
    public HandBrake handBrake;

    public GameObject pauseMenu;

    static  bool isRestarting;
    // Start is called before the first frame update
    void Start()
    {
        if (!isRestarting)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            menuPanel.SetActive(false);

            isRestarting = false;
        }
    }

   
    public void SetCurrentTrigger(TriggerChecker _checker)
    {
        checker = _checker;
    }
    public void PlayGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void DoorEnterButton()
    {
        checker.CarSettingsON();
    }
    public void DoorExitButton()
    {
        checker.CarSettingsOFF();
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void PauseCancel()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        isRestarting=true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }
    public void Home()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ActivateHandBrakeForCar(CarController controller)
    {
        if (handBrake == null)
        {
            Debug.LogWarning("HandBrake reference not set on UIManager.");
            return;
        }

        // Now assign the active car
        handBrake.SetActiveCar(controller);
    }
}
