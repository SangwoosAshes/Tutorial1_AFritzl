using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class car : MonoBehaviour
{
    public float accelaration;
    public float rotationSpeed;
    public float maxspeed;
    public Text txtSpeed;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AddSpeed();
        AddVelocity();
        AddRotation();

        txtSpeed.text = "Speed" + rigid.velocity.magnitude + "kn/H";

    }

    void AddSpeed()
    {
        if(rigid.velocity.magnitude<maxspeed)
        {
            float Inputforward = Input.GetAxis("Vertical");
            rigid.AddForce(transform.forward * accelaration * Inputforward);
        }
            
        
    }

    void AddRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, rotation*rotationSpeed, 0));
    }

    void AddVelocity()
    {
        Vector3 velocity = rigid.velocity;

        float direction = Vector3.Dot(transform.forward, velocity.normalized);

        if (direction > 0)
        {
            velocity = transform.forward * velocity.magnitude;
        }
        else if (direction < 0)
        {
            velocity = -transform.forward * velocity.magnitude;
        }

        rigid.velocity = velocity;
    
}
}
