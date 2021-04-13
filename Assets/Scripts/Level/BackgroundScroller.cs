﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
	public float parallaxSpeed = 0.125f;
	public Sprite bgSprite;
	public int layerSortIndex;

	private Transform[] bglayers;
	private int leftIndex;
	private int rightIndex;
	private float positionOffset;
	private float LastCameraX;

	void Awake () {
		bglayers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			bglayers[i] = transform.GetChild(i);
			bglayers[i].GetComponent<SpriteRenderer> ().sprite = bgSprite;
			bglayers[i].GetComponent<SpriteRenderer> ().sortingOrder = layerSortIndex;
			bglayers[i].GetComponent<SpriteRenderer> ().sortingLayerName = "Parallax Background";
		}

		positionOffset =  bglayers[0].GetComponent<SpriteRenderer>().bounds.size.x;
	}

	// Use this for initialization
	void Start () {
		LastCameraX = Camera.main.transform.position.x;

		leftIndex = 0;
		rightIndex = bglayers.Length - 1;
	}

	// Update is called once per frame
	void Update () {
		float cameraDeltaX = LastCameraX - Camera.main.transform.position.x;

		transform.position += new Vector3 (cameraDeltaX * parallaxSpeed, 0, 0) ;
		LastCameraX = Camera.main.transform.position.x;

		if (Camera.main.transform.position.x > bglayers[rightIndex].position.x) {
            ScrollRight();
        }

		if (Camera.main.transform.position.x < bglayers[leftIndex].position.x) {
			ScrollLeft ();
		}
	}

	private void ScrollLeft () {
		bglayers[rightIndex].transform.position = new Vector2 (bglayers [leftIndex].position.x - positionOffset, bglayers[leftIndex].position.y);
		bglayers[rightIndex].localScale = new Vector2 (bglayers[rightIndex].localScale.x * -1, bglayers[rightIndex].localScale.y);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = bglayers.Length - 1;
		}
	}

	private void ScrollRight () {
		bglayers[leftIndex].transform.position = new Vector2 (bglayers [rightIndex].position.x + positionOffset, bglayers[rightIndex].position.y);
		bglayers[leftIndex].localScale = new Vector2 (bglayers[leftIndex].localScale.x * -1, bglayers[leftIndex].localScale.y);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == bglayers.Length) {
			leftIndex = 0;
		}
	}
}
