using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{
    public GameObject BloodVein;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    private GameObject instantiatedObject;
    public bool objectPlaced = false;

    void Update()
    {
        if (!objectPlaced && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                if (hits.Count == 1)
                {
                    Pose hitPose = hits[0].pose;
                    instantiatedObject = Instantiate(BloodVein, hitPose.position, Quaternion.identity);
                    instantiatedObject.transform.rotation = Quaternion.identity;
                    objectPlaced = true;

                    
                    Vector3 cameraToBloodVein = instantiatedObject.transform.position - Camera.main.transform.position;
                    cameraToBloodVein.y = 0;
                    instantiatedObject.transform.position = Camera.main.transform.position + cameraToBloodVein;

                    
                    foreach (var plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }
                    planeManager.enabled = false;
                }
            }
        }
    }
}
