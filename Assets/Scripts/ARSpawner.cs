using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSpawner : MonoBehaviour
{
	public GameObject[] player;
	public GameObject placementIndicatorPrefab;
	public GameObject spawnButton;

	private GameObject placementIndicator;

	private ARRaycastManager arRaycast;
	private ARPointCloudManager cloudManager;

	private Pose placementPose;               //Data structure containing posision and rotation of 3D objects
	public bool placementPoseIsValid = false;

	void Start()
	{
		arRaycast = FindObjectOfType<ARRaycastManager>();
		cloudManager = FindObjectOfType<ARPointCloudManager>();
		placementIndicator = Instantiate(placementIndicatorPrefab, transform.position, transform.rotation);

        for (int i = 0; i < player.Length; i++)
		{
            player[i].SetActive(false);
		}
		spawnButton.SetActive(false);
	}

	void Update()
	{
		UpdatePlacementPose();
		UpdatePlacementIndicator();
	}

	private void UpdatePlacementIndicator()
	{
		if (placementPoseIsValid)
		{
			placementIndicator.SetActive(true);
			spawnButton.SetActive(true);
			placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
		}
		else
		{
			placementIndicator.SetActive(false);
			spawnButton.SetActive(false);
		}
	}

	private void UpdatePlacementPose()
	{
		var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		var hits = new List<ARRaycastHit>();
		arRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

		placementPoseIsValid = hits.Count > 0;
		if (placementPoseIsValid)
		{
			placementPose = hits[0].pose;

			var cameraForward = Camera.main.transform.forward;
			var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
			placementPose.rotation = Quaternion.LookRotation(cameraBearing);
		}
	}
	public void Spawn()
	{
		cloudManager.enabled = false;
        player[0].transform.position = placementPose.position;
		for (int i = 0; i < player.Length; i++)
		{
			player[i].SetActive(true);
		}
		Destroy(placementIndicator);
		spawnButton.SetActive(false);
	}
}
