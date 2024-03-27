using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARPlacement : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject arCamera;
    private Pose placementPose;
    private ARRaycastManager arRaycastManager;
    private bool placementPoseIsValid = false;

    private GameObject targetedObject; 

    public Button destroyButton; 

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        destroyButton.onClick.AddListener(DestroyTarget); 
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TargetObject();
        }
    }

    void UpdatePlacementIndicator()
    {
        placementIndicator.SetActive(placementPoseIsValid);
        if (placementPoseIsValid)
        {
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }

    void TargetObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("WhiteCell"))
            {
                targetedObject = hit.transform.gameObject;
            }
        }
    }

    void DestroyTarget()
    {
        if (targetedObject != null)
        {
            Destroy(targetedObject);
        }
    }
}