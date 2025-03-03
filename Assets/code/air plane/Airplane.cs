using Unity.VisualScripting;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    [SerializeField] public float enginePower = 20f;
    [SerializeField] public float liftBooster = 0.5f;
    [SerializeField] public float drag = 0.001f;
    [SerializeField] public float angularDrag = 0.001f;
    [SerializeField] public float yawPower = 50f;
    [SerializeField] public float pitchPower = 50f;
    [SerializeField] public float rollPower = 30f;
    // [SerializeField] public float
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower );
        } 
        //2
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
            rb.AddForce(transform.up * lift.magnitude * liftBooster);
        //3
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;
        //4
        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;
        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);


    }
}
