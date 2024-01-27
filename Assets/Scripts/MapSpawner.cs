using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject wall;
    public GameObject bouncer;
    private float wall_x;
    private float wall_y;
    // Start is called before the first frame update
    void Start()
    {
        wall_x = wall.transform.localScale.x;
        wall_y = wall.transform.localScale.y;
        for (int i = 0; i < 10; i++)
        {
            GameObject wal = Instantiate(wall);
            wal.transform.position = new Vector2(Random.Range(-6f, 6f), Random.Range(-5f, 5f));
            wal.transform.Rotate(0.0f, 0.0f, Random.Range(0, 360));
            wal.transform.localScale = new Vector2(wall_x * Random.Range(0.5f, 2f), wall_y * Random.Range(1f, 2f));
        }
        for (int i = 0;i < 5;i++)
        {
            GameObject bounc = Instantiate(bouncer);
            bounc.transform.position = new Vector2(Random.Range(-6f, 6f), Random.Range(-5f, 5f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
