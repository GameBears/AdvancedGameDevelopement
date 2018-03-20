using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {
    Actions action;

    // Use this for initialization
    void Start()
    {
        action = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (action.done)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "NotVisible";
        }
    }
}
