using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject wall;
    public GameObject bouncer;
    public GameObject[] spawnPoints;
    private float wall_x;
    private float wall_y;
    // Start is called before the first frame update
    void Start()
    {
        wall_x = wall.transform.localScale.x;
        wall_y = wall.transform.localScale.y;
        for (int i = 0; i < 7; i++)
        {
            GameObject wal = Instantiate(wall);
            wal.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-4f, 4f));
            //Also change in Spawner
            wal.transform.Rotate(0.0f, 0.0f, Random.Range(0, 360));
            wal.transform.localScale = new Vector2(wall_x * Random.Range(0.5f, 2f), wall_y * Random.Range(1f, 2f));
        }
        for (int i = 0;i < 5;i++)
        {
            GameObject bounc = Instantiate(bouncer);
            bounc.transform.position = new Vector2(Random.Range(-6f, 6f), Random.Range(-4f, 4f));
        }
        foreach (var spawnPoint in spawnPoints)
        {
            GameObject spawn = Instantiate(spawnPoint);
            spawn.transform.position = spawnPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RandomizeSpawn()
    {
        foreach (GameObject gameObject in spawnPoints)
        {
            Collider2D collider = gameObject.GetComponent<CircleCollider2D>();
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            List<Collider2D> results = new List<Collider2D>();
            do
            {
                gameObject.transform.position = new Vector2(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-4f, 4f));
            } while (collider.OverlapCollider(filter, results) > 0);
        }
    }
}
