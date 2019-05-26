using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backwheel : MonoBehaviour
{
    Rigidbody rb;

    bool forward = false;
    bool backward = false;
    //public float thrust;
    float thrust = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Forward"))
        {
            forward = true;
        }else if (Input.GetButtonUp("Forward"))
        {
            forward = false;
        }

        if (Input.GetButtonDown("Backward"))
        {
            backward = true;
        }
        else if (Input.GetButtonUp("Backward"))
        {
            backward = false;
        }

        if (Input.GetAxis("Horizontal") > 0) //Right
        {
            //Debug.Log("Right");
            //rb.MoveRotation = new Vector3 (0 , 0, -90);
        }

        if (Input.GetAxis("Horizontal") < 0) //Left
        {
            //Debug.Log("Left");
            GetComponent<Transform>().eulerAngles = new Vector3 (0, 0, 90);
        }
    }

    private void FixedUpdate()
    {
        if (forward)
        {
            rb.velocity = new Vector3(0, 0, thrust);
        }

        if (backward && !forward)
        {
            rb.velocity = new Vector3(0, 0, -thrust);
        }

        if (backward && forward)
        {
            rb.velocity = new Vector3(0, 0, -thrust / 60);
        }
    }
}
