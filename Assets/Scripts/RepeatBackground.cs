using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startpos;
    private float repeatWith;
    // Start is called before the first frame update
    void Start()
    {
        startpos= transform.position;
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startpos.x - repeatWith)
        {
            transform.position = startpos;
        }
    }
}
