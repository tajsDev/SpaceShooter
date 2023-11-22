using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("insribed")]
    public float duration = 10;

    static public int bombCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke(nameof(DestroyBomb), duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
