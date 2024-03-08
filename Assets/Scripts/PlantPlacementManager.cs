using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject BloodVein;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;

    public GameObject crosshair;


    private GameObject instantiatedObject;
    private bool objectPlaced = false;

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

                    Destroy(crosshair);
                    Pose hitPose = hits[0].pose;
                    instantiatedObject = Instantiate(BloodVein, hitPose.position, Quaternion.identity);
                    instantiatedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    objectPlaced = true;


                    
                    foreach (var plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }
                    planeManager.enabled = false;
                }
            }
        }
        /*else if (objectPlaced && Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                float scaleFactor = 0.01f;
                instantiatedObject.transform.localScale += new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0) * scaleFactor;
            }
        }*/
    }
}
