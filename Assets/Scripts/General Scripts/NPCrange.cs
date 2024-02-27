using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCrange : MonoBehaviour
{

    float range;

    // Start is called before the first frame update
    void Start()
    {
        range = gameObject.transform.parent.GetComponent<NPCScript>().vision;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(2*range,2*range, 1);
    }
}
