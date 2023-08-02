using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform enemy;
    public GameObject radar;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy.position = Vector3.forward;
       
    }

    // Update is called once per frame
    void Update()
    {
     
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, enemy.position, step);
       // Debug.Log(enemy.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
