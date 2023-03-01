using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceScript : MonoBehaviour
{
    private bool firstPlaced = false;
    private bool secondPlaced = false;
    private bool toggle = false;
    public GameObject placeableObject;
    public GameObject placeableObject2;
    private GameObject referenceToPlacedObject;
    private GameObject referenceToPlacedObject2;
    private ARRaycastManager ar_RayCastManager;
    private Vector2 touchPos;
    static List<ARRaycastHit> rayCastHits = new List<ARRaycastHit>();
    
    void Awake()
    {
        ar_RayCastManager = GetComponent<ARRaycastManager>();


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
        if (!toggle)
        {
            if (!TryTouchPos(out Vector2 touchPos))
            {
                return;
            }

            if (ar_RayCastManager.Raycast(touchPos, rayCastHits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = rayCastHits[0].pose;

                if (referenceToPlacedObject == null && firstPlaced == false)
                {
                    referenceToPlacedObject = Instantiate(placeableObject, hitPose.position + new Vector3(0, 0, 0), hitPose.rotation);
                    firstPlaced = true;
                }
                else
                {
                    //referenceToPlacedObject.GetComponent<Rigidbody>().MovePosition(referenceToPlacedObject.transform.position + new Vector3(hitPose.position.x, 0, hitPose.position.z) * Time.deltaTime * 3);
                    referenceToPlacedObject.transform.position = Vector3.MoveTowards(referenceToPlacedObject.transform.position, hitPose.position, 3 * Time.deltaTime);
                    //referenceToPlacedObject.transform.position = hitPose.position;
                }
            }
            else
            {
                referenceToPlacedObject.GetComponent<CycleMat>().CycleMaterial();
            }
        }
        else if (toggle)
        {
            if (!TryTouchPos(out Vector2 touchPos))
            {
                return;
            }

            if (ar_RayCastManager.Raycast(touchPos, rayCastHits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose2 = rayCastHits[0].pose;

                if (referenceToPlacedObject2 == null && secondPlaced == false)
                {
                    referenceToPlacedObject2 = Instantiate(placeableObject2, hitPose2.position + new Vector3(0, 0, 0), hitPose2.rotation);
                    secondPlaced = true;
                }
                else
                {
                    //referenceToPlacedObject.GetComponent<Rigidbody>().MovePosition(referenceToPlacedObject.transform.position + new Vector3(hitPose.position.x, 0, hitPose.position.z) * Time.deltaTime * 3);
                    referenceToPlacedObject2.transform.position = Vector3.MoveTowards(referenceToPlacedObject2.transform.position, hitPose2.position, 3 * Time.deltaTime);
                    //referenceToPlacedObject.transform.position = hitPose.position;
                }
            }
            else
            {
                referenceToPlacedObject2.GetComponent<CycleMat>().CycleMaterial();
            }
        }

    }


    public void ToggleObject()
    {
        toggle = !toggle;
    }
}
