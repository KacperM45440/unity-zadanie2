using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float repeatRate;
    private float timer = 0;
    public float height;
    public GameObject prefabPipe;
    public Sprite redSprite;
    int i;

    // Update is called once per frame
    void Update()
    {
        if (timer > repeatRate)
        {
            timer = 0;
            SpawnPipe();
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        GameObject newPipe = Instantiate(prefabPipe);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

        i = Random.Range(0, 2);

        if (i.Equals(0))
        {
            newPipe.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = redSprite;
            newPipe.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = redSprite;
        }
        
        Destroy(newPipe, 10f);
    }
}
