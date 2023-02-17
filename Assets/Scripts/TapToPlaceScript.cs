using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceScript : MonoBehaviour
{
    public GameObject placeableObject;
    private GameObject referenceToPlacedObject;
    private ARRaycastManager ar_RayCastManager;
    private Vector2 touchPos;
    static List<ARRaycastHit> rayCastHits = new List<ARRaycastHit>();
    
    void Awake()
    {
        ar_RayCastManager.GetComponent<ARRaycastManager>();


    }

    private bool TryTouchPos(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }

    
    void Update()
    {
        if (!TryTouchPos(out Vector2 touchPos))
        {
            return;
        }

        if (ar_RayCastManager.Raycast(touchPos, rayCastHits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = rayCastHits[0].pose;

            if (referenceToPlacedObject == null)
            {
                referenceToPlacedObject = Instantiate(placeableObject, hitPose.position, hitPose.rotation);
            }
            else
            {
                referenceToPlacedObject.transform.position = hitPose.position;
            }
        }
        else
        {
            referenceToPlacedObject.GetComponent<CycleMat>().CycleMaterial();
        }

    }
}
