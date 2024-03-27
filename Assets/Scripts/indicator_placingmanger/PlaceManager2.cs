using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager2 : MonoBehaviour
{
    private PlaceIndicator2 placeIndicator;
    public GameObject objectToPlace;
    private GameObject newPlacedObject;


    public GameObject placementButton;
    public GameObject indicatoricon;
    public GameObject shooticon;
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator2>();
    }
    public void ClickToPlace()
    {
        newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
       
        placementButton.SetActive(false);
        indicatoricon.SetActive(false);
        shooticon.SetActive(true);

    }
}