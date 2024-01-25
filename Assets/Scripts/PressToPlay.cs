using UnityEngine;

public sealed class PressToPlay : MonoBehaviour
{
    [field:SerializeField] public KeyCode Key { get; set; }

    void Update()
    {
        if (Input.GetKeyDown(Key)) GetComponent<AudioSource>().Play();
    }
}
