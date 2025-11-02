using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerChecker : MonoBehaviour
{
    [Header("Cars")]
    public GameObject player;
    public GameObject halfCharacter;
    public GameObject kiraCamera;
    public GameObject carCamera;
    [Header("UI")]
    public Text enterText;
    public Text exitText;
    public Button doorEnter;
    public Button doorExit;
    public Image handBrake;
    public GameObject playerJoyStick;
    public GameObject gasButtons;

    public CarController controller;

    private bool inCar = false;
    private bool playerInTrigger = false;

    public UIManager uIManager;



    private void Update()
    {
        if(!inCar && playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            CarSettingsON();
        }
        if(inCar && Input.GetKeyDown(KeyCode.R))
        {
            CarSettingsOFF();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            enterText.gameObject.SetActive(true);
            doorEnter.gameObject.SetActive(true);
            playerInTrigger = true;
            uIManager.SetCurrentTrigger(this);
        }
      
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enterText.gameObject.SetActive(false);
            doorEnter.gameObject.SetActive(false);
            playerInTrigger = false;
        }
    }
    public void CarSettingsON()
    {
        uIManager.ActivateHandBrakeForCar(controller);

        player.SetActive(false);
        kiraCamera.SetActive(false);
        enterText.gameObject.SetActive(false);
        doorEnter.gameObject.SetActive(false);
        playerJoyStick.SetActive(false);
        gasButtons.SetActive(true);
        halfCharacter.SetActive(true);
        carCamera.SetActive(true);
        exitText.gameObject.SetActive(true);
        doorExit.gameObject.SetActive(true);
        handBrake.gameObject.SetActive(true);
        controller.isCarStarted = true;
        inCar = true;
    }
    public void CarSettingsOFF()
    {
        player.SetActive(true);
        kiraCamera.SetActive(true);
        playerJoyStick.SetActive(true);
        gasButtons.SetActive(false);
        halfCharacter.SetActive(false);
        carCamera.SetActive(false);
        exitText.gameObject.SetActive(false);
        doorExit.gameObject.SetActive(false);
        handBrake.gameObject.SetActive(false);
        controller.isCarStarted = false;
        inCar = false;

        player.transform.position = halfCharacter.transform.position;
    }
}
