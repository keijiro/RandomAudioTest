using UnityEngine;
using UnityEngine.Audio;

public sealed class PressToPlay : MonoBehaviour
{
    [field:SerializeField] public AudioResource Audio { get; set; }
    [field:SerializeField] public KeyCode Key { get; set; }

    bool _active;

    void Update()
    {
        var src = GetComponent<AudioSource>();
        if (Input.GetKey(Key))
        {
            if (!_active)
            {
                src.resource = Audio;
                src.loop = true;
                src.Play();
                _active = true;
            }
        }
        else
        {
            if (_active) src.Stop();
            _active = false;
        }
    }
}
