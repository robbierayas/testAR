using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    // Start is called before the first frame update
    void Start()
    {
    	//get the components
	Debug.Log("Start"); //TODO Debug not printing?
	Debug.Log("transfor"+transform);
	rayManager = FindObjectOfType<ARRaycastManager>();
    	visual = transform.GetChild(0).gameObject;
	Debug.Log("visual"+visual);
	// hide the placement idicator visual
	visual.SetActive(true);	//TODO change back to false
    }

    // Update is called once per frame
    void Update()
    {
	//Debug.Log("Update #1");
        // shoot a raycast from the center of the screen
	List<ARRaycastHit> hits = new List<ARRaycastHit>();
	rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

	// if we hit an AR plane surface, update the position and rotation
	if(hits.Count > 0)
	{
		Debug.Log("hits"); //debug not printing, Update runs but never hits.Count
		transform.position = hits[0].pose.position;
		transform.rotation = hits[0].pose.rotation;
		if(!visual.activeInHierarchy) {
			visual.SetActive(true);
		}
	}
    }
}
