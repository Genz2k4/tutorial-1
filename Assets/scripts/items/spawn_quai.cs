using System.Collections;
using UnityEngine;

public class spawn_quai : MonoBehaviour
{
    [SerializeField] GameObject[] quai;
    [SerializeField] float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn_wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn_wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            
            spawn();
        }
    }

    void spawn()
    {
        var random =  quai[Random.Range(0, quai.Length)];
        
        if (quai.Length > 0)
        {
            Instantiate(random, transform.position, Quaternion.identity);
        }
    }
}
