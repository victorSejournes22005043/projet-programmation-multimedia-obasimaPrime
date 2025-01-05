using UnityEngine;

public class Pepper : MonoBehaviour
{
    public float floatSpeed = 1f; 
    public float floatHeight = 0.5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BaltrouDeFeu fireScript = other.GetComponent<BaltrouDeFeu>();
            if (fireScript != null)
            {
                fireScript.PickUpPepper();
                Destroy(gameObject);
            }
        }
    }
}
