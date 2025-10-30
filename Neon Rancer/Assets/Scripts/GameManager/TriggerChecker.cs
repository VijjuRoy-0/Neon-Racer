using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public GameObject player;
    public GameObject kiraCamera;
    public GameObject carCamera;
    public GameObject popUpImage;
    public CarController controller;
    public GameObject halfCharacter;

    private bool inCar = false;
    private bool playerInTrigger = false;



    private void Update()
    {
        if(!inCar && playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
            kiraCamera.SetActive(false);
            popUpImage.SetActive(false);
            halfCharacter.SetActive(true);
            carCamera.SetActive(true);
            controller.isCarStarted = true;
            inCar = true;
        }
        if(inCar && Input.GetKeyDown(KeyCode.R))
        {
            player.SetActive(true);
            kiraCamera.SetActive(true);
            //popUpImage.SetActive(false);
            halfCharacter.SetActive(false);
            carCamera.SetActive(false);
            controller.isCarStarted = false;
            inCar=false;

          player.transform.position =  halfCharacter.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            popUpImage.SetActive(true);
            playerInTrigger = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popUpImage.SetActive(false);
            playerInTrigger = false;
        }
    }
}
