using UnityEngine;
using Unity.Mathematics;
using Klak.Motion;

public sealed class PressToWalk : MonoBehaviour
{
    [field:SerializeField] public KeyCode Key { get; set; }
    [field:SerializeField] public float Acceleration { get; set; }
    [field:SerializeField] public float MaxSpeed { get; set; }
    [field:SerializeField] public float LoopLength { get; set; }
    [field:SerializeField] public BrownianMotion Jitter { get; set; }

    float _speed;
    float _progress;

    (float3 pos, float3 rot) _jitterAmount;

    void Start()
    {
        _jitterAmount.pos = Jitter.positionAmount;
        _jitterAmount.rot = Jitter.rotationAmount;
    }

    void Update()
    {
        var dt = Time.deltaTime;
        var dspeed = Acceleration * dt * (Input.GetKey(Key) ? 1 : -1);
        _speed = math.saturate(_speed + dspeed);
        _progress += _speed * MaxSpeed * dt;

        transform.localPosition = math.float3(0, 0, math.frac(_progress) * LoopLength);

        Jitter.positionAmount = _jitterAmount.pos * _speed;
        Jitter.rotationAmount = _jitterAmount.rot * _speed;
    }
}
