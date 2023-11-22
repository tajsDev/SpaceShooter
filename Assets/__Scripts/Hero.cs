using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; }
    [Header("inscribed")]
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("dynamic")]
    private float _shieldLevel = 4;

    private GameObject lastTriggerGo;
    // Start is called before the first frame update
    void Awake()
    {
        if(S==null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to create a hero that is not null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;

        transform.position = pos;
        transform.rotation = Quaternion.Euler(vAxis * pitchMult, hAxis * rollMult, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
        
    }
    public float shieldLevel
    {
        get { return (_shieldLevel); }
        private set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if(value < 0)
            {
                Destroy(this.gameObject);
                Main.HERO_DIED();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go == lastTriggerGo) return;
        lastTriggerGo = go;
 
        shieldLevel--;
        
        Destroy(go);
        

    }
    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * projectileSpeed;

    }

}
