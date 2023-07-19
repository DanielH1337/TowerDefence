using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject towerBaseParent;
    public float rotateSpeed = 100;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
       // float inputY = Input.GetAxis("Vertical");
        Vector3 LookHere = new Vector3(0, inputX * rotateSpeed * Time.deltaTime, 0);
        //  Vector3 moveHere = new Vector3()
        if (Input.GetKey(KeyCode.W))
        {
            towerBaseParent.transform.Translate(transform.forward * speed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            towerBaseParent.transform.Translate((transform.forward*-1) * speed * Time.deltaTime, Space.Self);
        }
        
        
        transform.Rotate(LookHere);
    }
}
