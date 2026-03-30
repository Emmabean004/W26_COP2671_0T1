
using UnityEngine;

public class MoveDownward : MonoBehaviour
{ 
    public GameObject player;
    public int counterScore = 0;
    
    // find object for the plane
    public GameObject floor;
    [SerializeField] private float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            
        }
    }
}



