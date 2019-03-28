using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;

	void Start () {
		
	}
	
	void Update ()
	{
        transform.Translate(Vector3.up*bulletSpeed*Time.deltaTime, Space.Self);
	}

}
