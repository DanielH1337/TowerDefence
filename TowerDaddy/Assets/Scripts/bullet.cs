using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform enemy;
    public GameObject radar;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        radar.GetComponentInChildren<enemyDetect>();
        enemy.position = Vector3.forward;
       
    }

    // Update is called once per frame
    void Update()
    {
        //enemy.position = radar.GetComponentInChildren<enemyDetect>().enemyTransform;
        rb.transform.Translate(enemy.transform.position*speed);
        Debug.Log(enemy.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
