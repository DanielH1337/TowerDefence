using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //  transform.Rotate(LookHere);
            
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            if (Input.GetKey(KeyCode.W))
            {
                //towerBaseParent.transform.Translate(transform.forward * speed * Time.deltaTime, Space.Self);
                GetComponent<Rigidbody>().MovePosition(transform.position + m_Input * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //towerBaseParent.transform.Translate((transform.forward * -1) * speed * Time.deltaTime, Space.Self);
                GetComponent<Rigidbody>().MovePosition(transform.position + m_Input * speed * Time.deltaTime);
            }

        }
    }
}
