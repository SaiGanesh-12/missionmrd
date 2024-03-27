using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator2 : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    public GameObject pointer;

    void Start()
    {
        raycastManager = FindAnyObjectByType<ARRaycastManager>();
        pointer = this.transform.GetChild(0).gameObject;
        pointer.SetActive(false);
    }
    private void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);
        if (hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if (!pointer.activeInHierarchy)
            {
                pointer.SetActive(true);
            }
        }
    }

}