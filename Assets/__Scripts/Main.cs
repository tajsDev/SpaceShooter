using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static private Main S;
    // Start is called before the first frame update
    [Header("Inscribed")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyInsetDefault = 1.5f;
    public float gameRestartDelay = 2;

    private BoundsCheck bndCheck;
    void Awake()
    {
        S = this;

        bndCheck = GetComponent<BoundsCheck>();
        Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
    }
    private void FixedUpdate()
    {
        if(ScoreTracker.NUM_ENEMIES < 0)
        {
            HERO_LIVED();
        }
    }
    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyInset = enemyInsetDefault;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyInset = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);

            Vector3 pos = Vector3.zero;
            float xMin = -bndCheck.camWidth + enemyInset;
            float xMax = bndCheck.camWidth - enemyInset;

            pos.x = Random.Range(xMin, xMax);
            pos.y = bndCheck.camHeight + enemyInset;
            go.transform.position = pos;

            Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
        }
    }

    static public void HERO_DIED()
    {
        SceneManager.LoadScene("LoseEndCard");
    }
    static public void HERO_LIVED()
    {
        SceneManager.LoadScene("WinEndCard");
    }

    
}
