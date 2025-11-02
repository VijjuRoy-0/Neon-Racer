using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandBrake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private CarController carController;

    private void Start()
    {
      
    }
    public void SetActiveCar(CarController _carController)
    {
        carController = _carController;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        carController.isbraking = true;
     
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        carController.isbraking= false;
     
    }


}
