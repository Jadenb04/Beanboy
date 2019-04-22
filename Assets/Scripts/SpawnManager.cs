using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxPlatforms = 20;
    public GameObject platform;






    public float horizontalMin = 6.5f;
    public float horizontalMax = 14f;


    public float verticalMin = -6f;
    public float verticalMax = 6f;

    private Vector2 originPosition;


    
    
    
    
    // Start is called before the first frame update
    private void Start()
    {

        originPosition = transform.position;

        Spawn();
        


    }

    private void Spawn()
    {
        for (int platformCounter = 0; platformCounter < maxPlatforms; platformCounter++)

        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));


            Instantiate(platform, randomPosition, Quaternion.identity);

            originPosition = randomPosition;
        }
    }
}
