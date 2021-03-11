using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int damge = 1;
	public float fireTime = 0.3f;
	public float lastFireTime = 0;
	// Use this for initialization
	void Start () {
		UpdateFireTime ();
	}

	void UpdateFireTime()
	{
		lastFireTime = Time.time;
	}
	void Fire()
	{
		if (Time.time >= lastFireTime + fireTime) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				if (hit.transform.tag.Equals ("Zombie")) 
				{
					hit.transform.gameObject.GetComponent<ZombieController> ().GetHit (damge);
				}
			}
			UpdateFireTime ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) 
		{
			Fire ();
		}
	}
}
