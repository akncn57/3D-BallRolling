using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public float speed = 1f;
    private float horizontalMove;
    public Rigidbody rb;
    public Transform way1, way2;
    public GameObject death_effect;
    public GameObject coin_effect;
    public GameObject DeathUI;
    public GameObject InGameUI;
    public int score = 0;
    public Text scoreText;
    public Text scoreDeathText;
    public Text highScoreText;
    public Text highScoreDeathText;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Score();
    }

    private void Update()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        highScoreDeathText.text = PlayerPrefs.GetInt("HighScore").ToString();
        horizontalMove = Input.acceleration.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Hit obstacle.
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }

        // Fall.
        if (other.CompareTag("FallCheck"))
        {
            GameOver();
        }

        // Hit coin.
        if (other.CompareTag("Coin"))
        {
            Instantiate(coin_effect, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

        // Infinity Way.
        if (other.CompareTag("Way1"))
        {
            way2.position = new Vector3(way1.position.x, way1.position.y, way1.position.z + 20f);
        }
        if (other.CompareTag("Way2"))
        {
            way1.position = new Vector3(way2.position.x, way2.position.y, way2.position.z + 20f);
        }
    }

    private void Move()
    {
        
        rb.AddForce(new Vector3(horizontalMove, 0, 0) * speed);
    }

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
        scoreDeathText.text = score.ToString();
    }

    private void GameOver()
    {
        Instantiate(death_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Time.timeScale= 0;
        InGameUI.SetActive(false);
        DeathUI.SetActive(true);

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
