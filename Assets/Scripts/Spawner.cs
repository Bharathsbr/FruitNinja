using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider sc;

    public GameObject[] fruitPrefab;
    public GameObject bombprefab;

    [Range(0f,1f)]
    public float bombtime=0.05f;

    public float maxlife=7f;

    public float maxspawndelay=1f;
    public float minspawndelay=0.25f;

    public float maxangle=15f;
    public float minangle=-15f;

    public float minforce=18f;
    public float maxforce=22f;

    private void Awake()
    {
        sc=GetComponent<Collider>();


    }


    private void OnEnable(){
        StartCoroutine(Spawn());
    }

    private void OnDisable(){
        StopAllCoroutines();
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while(enabled){
            GameObject prefab=fruitPrefab[Random.Range(0,fruitPrefab.Length)];

            if(Random.value<bombtime){
                prefab=bombprefab;
            }
            
            Vector3 position=new Vector3();
            position.x=Random.Range(sc.bounds.min.x,sc.bounds.max.x);
            position.y=Random.Range(sc.bounds.min.y,sc.bounds.max.y);
            position.z=Random.Range(sc.bounds.min.z,sc.bounds.max.z);

            Quaternion rotation=Quaternion.Euler(0f,0f,Random.Range(minangle,maxangle));

            GameObject fruit=Instantiate(prefab,position,rotation);
            Destroy(fruit,maxlife);

            float force=Random.Range(minforce,maxforce);

            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up*force,ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minspawndelay,maxspawndelay));
        }
    }
    
}

