using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 LookHere = new Vector3(0, inputX * rotateSpeed * Time.deltaTime, 0);
        transform.Rotate(LookHere);
    }
}
