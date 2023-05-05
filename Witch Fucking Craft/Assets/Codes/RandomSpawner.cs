using UnityEngine;
[System.Serializable]
public class Spawned
{
    public string Name;
    public GameObject Prefab;
    [Range(0f, 100f)] public float Chance = 100f;
    [HideInInspector] public double _weight;
}
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] public Spawned[] spawned;
    private double accumulatedWeights;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    private void Awake()
    {
        CalculateWeights();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void SpawnedRandomThinks(Vector3 position)
    {
        // düzeltilmesi lazým 
        Spawned randomCustomer = spawned[GetRandomIndex()]; //spawned[Random.Range(0, spawned.Length)];
        Instantiate(randomCustomer.Prefab, position,Quaternion.identity, transform);
        Debug.Log(randomCustomer.Prefab.name);
        
    }
    private int GetRandomIndex()
    {
        double r = rand.NextDouble()*accumulatedWeights;
        for(int i=0; i < spawned.Length; i++)
        {
            if (spawned[i]._weight >= r)
            {
                return 1;
            }
        }
        return 0;
    }
    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (Spawned spawned in spawned)
        {
            accumulatedWeights += spawned.Chance;
            spawned._weight = accumulatedWeights;   
        }
    }
}
