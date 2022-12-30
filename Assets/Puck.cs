using System;
using UnityEngine;

public class Puck : MonoBehaviour
{
     //  public static Puck instance;
     //[SerializeField]
     private Vector3 startPostition;
     private Rigidbody rb;
     
    void Awake()
    {
        startPostition = transform.position;
        rb = GetComponent<Rigidbody>();
        //   instance = this;
    }

    private void Update()
    {
        rb.velocity = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward).normalized*10;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HI");
        if (other.CompareTag("GoalRed"))
        {
            Manager.instance.ScoredGoal(false);
            ResetPuck();
            
        }else if (other.CompareTag("GoalBlue"))
        {
            Manager.instance.ScoredGoal(true);
            ResetPuck();
        }
    }

    private void ResetPuck()
    {
        transform.position = startPostition;
        rb.velocity = Vector3.zero;
    }
}
