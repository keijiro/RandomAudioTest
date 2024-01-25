using UnityEngine;

public sealed class PressToEnable : MonoBehaviour
{
    [field:SerializeField] public KeyCode Key { get; set; }

    void Update()
      => GetComponent<AudioSource>().enabled = Input.GetKey(Key);
}
