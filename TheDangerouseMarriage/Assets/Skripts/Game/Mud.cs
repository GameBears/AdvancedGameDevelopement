using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour {
    Actions actionDoVacuum;

	// Use this for initialization
	void Start () {
        actionDoVacuum = GetComponent<Actions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (actionDoVacuum.done)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "NotVisible";
        }
	}
}
