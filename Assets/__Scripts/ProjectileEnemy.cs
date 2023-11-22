using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy: MonoBehaviour
{
    private BoundsCheck bndCheck;
    public float fireRate = 0.3f;
    public float projectileSpeed = 40;
    public GameObject projectilePrefab;
    public GameObject bombPrefab;
    public string function;
    // Start is called before the first frame update
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    void Start()
    {
        Invoke(function,fireRate);
    }
    // Update is called once per frame
    void Update()
    {
        if(!bndCheck.isOnScreen)
        {
            Destroy(gameObject);
        }
        
    }
    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.down * projectileSpeed;
        Invoke("TempFire",fireRate);

    }
    void LaunchBomb()
    {
        GameObject bombGO = Instantiate<GameObject>(bombPrefab);
        bombGO.transform.position = transform.position;
        Invoke("LaunchBomb",fireRate);
    }
    void HorzFire()
    {
        LeftFire();
        RightFire();
        
        Invoke("HorzFire",fireRate);

    }
    void LeftFire()
    {
        GameObject projGoRight=Instantiate<GameObject>(projectilePrefab);
        projGoRight.transform.position = transform.position;
        projGoRight.transform.rotation = Quaternion.Euler(0,0,90);
        Rigidbody rigidBRight = projGoRight.GetComponent<Rigidbody>();
        rigidBRight.velocity = Vector3.right* projectileSpeed;

    }
    void RightFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.rotation = Quaternion.Euler(0,0,90);
        projGO.transform.position = transform.position;
        
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        
        rigidB.velocity = Vector3.left* projectileSpeed;

    }
    void FinalFire()
    {
        
        LeftFire();
        RightFire();
        TempFire();

        Invoke("FinalFire",fireRate);
    }
    
}
