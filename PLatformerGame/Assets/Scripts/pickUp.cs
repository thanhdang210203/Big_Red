using UnityEngine;

public class pickUp : MonoBehaviour
{
    [SerializeField] private int healthValue;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health_Sys>().TakePortion(healthValue);
            gameObject.SetActive(false);
            Debug.Log("Gain health");
        }
    }
}