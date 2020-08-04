using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public string currentColor;
    public SpriteRenderer sr;
    public Color colorYellow;
    public Color colorPink;
    public Color colorCyan;
    public Color colorMagenta;


    // Start is called before the first frame
    void Start()
    {
        RandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = jumpForce * Vector2.up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(collision.gameObject);
        } else if(currentColor != collision.tag)
        {
            GameOver();
        }
    }


 
    void RandomColor()
    {
        int color = Random.Range(0, 4);
        switch(color)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }


    void GameOver()
    {
        Debug.Log("Game Over");
        jumpForce = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
