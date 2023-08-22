using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 center;
    [SerializeField] Vector3 size;
    [SerializeField] float minGap;
    [SerializeField] GameObject stalactite;
    [SerializeField] int attemptedSpawns;
    private List<Vector3> spawns = new List<Vector3>();
    private bool spawn;
    private Vector3 curpos;
    public float scaleMin;
    public float scaleMax;
    public float globalscaleMulti;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float zMin;
    public float zMax;

    

    // Start is called before the first frame update
    void Start()
    {
        int spawnCount = attemptedSpawns;
        while (spawnCount > 0)
        {
            SpawnStalactite();
            spawnCount--;

        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SpawnStalactite();
        }
    }

    public void SpawnStalactite()
    {


        spawn = true;
        curpos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
        for (int i =0; i < spawns.Count; i++)
        {
           if (AbsDiff(curpos.x, spawns[i].x) < minGap)
           {
               spawn = false;
           }
        }

        if (spawn)
        {
            Vector3 randomisedScale = Vector3.one;
            randomisedScale = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            stalactite.transform.localScale = randomisedScale * globalscaleMulti;
            
            Instantiate(stalactite, curpos, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            spawns.Add(curpos);
        }


    }

    private double AbsDiff(double a, double b)
    {
        if (a > b)
        {
            return a - b;
        }
        else
        {
            return b - a;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }

    
}
