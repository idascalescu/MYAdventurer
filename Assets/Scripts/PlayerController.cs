using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float fuel;

    public float maxFuel = 300;
    
    [SerializeField]
    private float fuelBurningRate = 1.8f;

    public float speed;
    public float jumpPower;
    public float rotationSensitivity;
   
    public GameObject FPSCamera;
    public GameObject UpperBody;

    private float CurrentCameraRotation;

    Vector3 offSet;
    Vector3 force;

    public Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = (Vector3.up * jumpPower * Time.deltaTime * 33.0f);
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKey("w"))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(force, ForceMode.Force); 
            }

            //Horizontal rotation of character
            float rotation_Y = Input.GetAxis("Mouse X");
            Vector3 rotationVectorY = new Vector3(0.0f, rotation_Y, 0.0f) * rotationSensitivity;

            Vector3 currRotation = transform.rotation.eulerAngles;
            Vector3 finalRotation = currRotation + rotationVectorY;
            transform.rotation = Quaternion.Euler(finalRotation);

            ////Vertical rotation of camera and body parts ;)
            float verticalRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;

            CurrentCameraRotation -= verticalRotation;
            CurrentCameraRotation = Mathf.Clamp(CurrentCameraRotation, -85, 85);
            UpperBody.transform.localEulerAngles = new Vector3(CurrentCameraRotation, 0.0f, 0.0f);
            
            PlayerFuelBar.fuelSlider.value = fuel;
        }  
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            fuel -= fuelBurningRate * Time.deltaTime;
            if(fuel <= 0.0f)
            {
                Explode();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            fuel += 50.0f;
            Destroy(collision.gameObject);
        }
    }

    private void Explode()
    {
        Debug.Log(" No fuel ");
        jumpPower = 0.0f;
    }
}