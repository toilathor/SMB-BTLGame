using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private float jumb = 20f;
    private int countScore = 0;
    private Text txtScore;
    private Text txtHightScore;
    private int hightcore;
    private Text txtHeath;
    private Animator anim;
    private Rigidbody2D rigi;

    public bool grounded = true;
    public bool doubleJumb = false;

    public int ourHealth = 5;
    public int maxHealth = 5;

    public SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        txtScore = GameObject.Find("textScore").GetComponent<Text>();
        txtHightScore = GameObject.Find("txtHightScore").GetComponent<Text>();
        txtHeath = GameObject.Find("txtHeath").GetComponent<Text>();
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();

        //chỗ này là để test nếu xuất bản thì phải xóa
        PlayerPrefs.SetInt("hightscore", 0);

        txtHightScore.text = ("Hight Score: " + PlayerPrefs.GetInt("hightscore"));
        hightcore = PlayerPrefs.GetInt("hightscore", 0);

        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    private void Update()
    {
        anim.SetBool("Grounded", grounded);

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doubleJumb = true;
                gameObject.GetComponent<Rigidbody2D>().velocity
                      = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumb);
            }
            else
            {
                if (doubleJumb)
                {
                    sound.Playsound("jumb");
                    doubleJumb = false;
                    gameObject.GetComponent<Rigidbody2D>().velocity
                      = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumb);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walk", true);
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Walk", true);
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            sound.Playsound("Coin");

            Destroy(collision.gameObject);
            txtScore.text = "Score: " + ++countScore;
            if (PlayerPrefs.GetInt("hightscore") < countScore)
            {
                PlayerPrefs.SetInt("hightscore", countScore);
                txtHightScore.text = ("Hight Score: " + PlayerPrefs.GetInt("hightscore"));
            }

        }
        
        if (collision.gameObject.tag == "Monster")
        {
            ourHealth--;

        }
        txtHeath.text = "<3:  " + ourHealth;

        
        if (ourHealth <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "finalMapThor")
        {
            SceneManager.LoadScene("MapSkyHuy");
        }
        if (collision.gameObject.tag == "finalMapHuy")
        {
            SceneManager.LoadScene("Map2_phu");
        }
        txtHeath.text = "<3:  " + ourHealth;

        if (collision.gameObject.tag == "Bottom")
        {
            Death();
        }
    }

    public void Death()
    {
        if (PlayerPrefs.GetInt("hightscore") < countScore)
        {
            PlayerPrefs.SetInt("hightscore", countScore);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
