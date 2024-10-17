using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool levelStart;
    public float jumpForce;
    public GameObject gameController;
    private int score;
    public Text scoreText;
    public GameObject message;

    private void Awake()
    {
       rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }




    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           // SoundController.instance.PlayThisSound("wing", 0.5f);
            if (levelStart == false)
            {
                levelStart = true;
                rigidbody.gravityScale = 2;
                gameController.GetComponent<PipeGenerator>().enableGenratePipe = true;
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();
        }
    }
    private void BirdMoveUp()
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReLoadScence();  
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    public void ReLoadScence()
    {
        SceneManager.LoadScene("_gameplay");
    }
}
