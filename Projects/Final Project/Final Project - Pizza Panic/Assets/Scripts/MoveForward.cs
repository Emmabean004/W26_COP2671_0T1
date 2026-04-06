
using UnityEngine;

public class MoveForward : MonoBehaviour
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
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z > 10)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            Destroy(gameObject);
        }
    }
}



