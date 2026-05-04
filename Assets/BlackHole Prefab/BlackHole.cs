using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float lifeTime = 2.0f;
    void Start()
    {
        Destroy(gameObject, lifeTime); // ยิงแล้วหายไปเองใน 2 วินาที
    }
}