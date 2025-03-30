using UnityEngine;

public class Sound : MonoBehaviour
{
    void Update()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
