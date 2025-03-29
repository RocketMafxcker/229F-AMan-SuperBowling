using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    float power = 0f;
    float maxPower = 500f;
    [SerializeField] Slider slider;
    float rollPower = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (power < maxPower)
            {
                power = power + 70;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.forward * power);
            //AudioSource source = GetComponent<AudioSource>();
            //source.Play();
        }
        if (transform.position.z > -9)
        {
            float roll = Input.GetAxis("Horizontal") * rollPower;
            rb.AddTorque(transform.forward * roll);
        }
        power--;
        slider.value = power;
    }
}
