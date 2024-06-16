using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Include this to use UI elements

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public int health = 5;
    private int score = 0;

    private Rigidbody rb;

    // Reference to the Text UI element
    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText(); // Initialize score text
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            UpdateScoreText(); // Update score text when score changes
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Method to update the score text
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
