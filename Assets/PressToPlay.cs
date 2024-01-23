using UnityEngine;
using UnityEngine.Audio;

public sealed class PressToPlay : MonoBehaviour
{
    [field:SerializeField] public AudioResource Audio { get; set; }
    [field:SerializeField] public KeyCode Key { get; set; }

    void Update()
    {
        var src = GetComponent<AudioSource>();
        if (Input.GetKey(Key))
        {
            if (!src.isPlaying)
            {
                src.resource = Audio;
                src.Play();
            }
        }
        else
        {
            src.Stop();
        }
    }
}
