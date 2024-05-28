using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj;
    public GameObject Lever;
    public float offset;
    void Start()
    {
        Obj.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Obj.transform.position = new Vector3( 0, 0.3f, Lever.transform.position.z - 1.27f);
    }
}
