using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject towerBaseParent;
    public float rotateSpeed = 100;
    public float speed = 100;
    public bool canMove;
  
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
        

        if (canMove)
        {
            transform.Rotate(LookHere);
            //towerBaseParent.transform.Rotate(LookHere);
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.W))
            {
                towerBaseParent.transform.Translate(transform.forward * speed * Time.deltaTime, Space.Self);
                //towerBaseParent.GetComponent<Rigidbody>().MovePosition(transform.position+m_Input * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                towerBaseParent.transform.Translate((transform.forward * -1) * speed * Time.deltaTime, Space.Self);
                //towerBaseParent.GetComponent<Rigidbody>().MovePosition(transform.position + m_Input * speed * Time.deltaTime);
            }
            
        }
        
    }
}
