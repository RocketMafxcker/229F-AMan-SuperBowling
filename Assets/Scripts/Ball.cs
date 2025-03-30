using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    float power = 0f;
    float maxPower = 500f;
    [SerializeField] Slider slider;
    float rollPower = 2f;
    float weightFeeling = 30f;
    [SerializeField] Button light;
    [SerializeField] Button medium;
    [SerializeField] Button heavy;
    public static float startTime = 99999999999999999999999999999999999999f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            if (power < maxPower)
            {
                power = power + weightFeeling;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * power);
            power = 0f;
            startTime = Time.time;
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
        if (transform.position.z > -9)
        {
            float roll = Input.GetAxis("Horizontal") * rollPower;
            rb.AddTorque(transform.forward * roll);
        }
        if(power > 0)
        {
            power--;
        }
        light.onClick.AddListener(() => AddMass(0.5f,40f));
        medium.onClick.AddListener(() => AddMass(1f, 30f));
        heavy.onClick.AddListener(() => AddMass(1.5f, 25f));
        slider.value = power;
    }
    void AddMass(float mass, float feeling)
    {
        rb.mass = mass;
        weightFeeling = feeling;
    }
}
