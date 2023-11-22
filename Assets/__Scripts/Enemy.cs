using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoundsCheck))]
public class Enemy : MonoBehaviour
{
    [Header("inscribed")]
    public float speed = 10f;
    public float health = 10;
    public int score = 100;
    public ParticleSystem burstCollision;

    private BoundsCheck bndCheck;
    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        burstCollision.Play();
        var em = burstCollision.emission;
        em.enabled = false;
        bndCheck = GetComponent<BoundsCheck>();
    }
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if(!bndCheck.isOnScreen)
        {
            if(pos.y < bndCheck.camHeight - bndCheck.radius)
            {
                ScoreTracker.NUM_ENEMIES--;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if(otherGO.GetComponent<ProjectileHero>() != null || otherGO.GetComponent<Bomb>() != null)
        {
            if (otherGO.GetComponent<Bomb>() != null)
                Bomb.bombCount--;
            
            var em = burstCollision.emission;
            em.enabled = true;
            var dur = burstCollision.main.duration;
            burstCollision.Play();
            Destroy(otherGO);
            ScoreTracker.score+=score;
            ScoreTracker.NUM_ENEMIES--;
            burstCollision.transform.parent = null; 
            Invoke(nameof(DestroyEnemy), 0);
            


        }
        else
        {
            Debug.Log("Enemy Hit by Non Projectile Hero " + otherGO.name);
        }
    }

    private void DestroyEnemy()
    {

        Destroy(gameObject);
    }


}
