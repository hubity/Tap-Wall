using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plyer : MonoBehaviour
{

    Rigidbody2D rb;

    int jumpX = 4;
    int jumpY = 12;
    
    public GameObject wallBounceEffectObj;
    public GameObject deadEffectObj;

    bool isDead = false;

    public CameraShake cameraShake;
    public GameManager gameManagerScript;

    public bool isPlay;

    public Sprite[] sprite;

    SpriteRenderer spritePlayer;

    public int player;
    GraphicRaycaster raycaster;
    void Start()
    {
        spritePlayer = gameObject.GetComponent<SpriteRenderer>();
        
        this.raycaster = GetComponent<GraphicRaycaster>();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }
    void Update()
    {
        player = PlayerPrefs.GetInt("player");
        spritePlayer.sprite = sprite[player];

        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                isPlay = false;
            }
            else
            {
                InputJump();
            }         
        }
    }
    public void InputJump()
    {
            rb.simulated = true;
            isPlay = true;
            if(isPlay == true)
            {
                    if (rb.velocity.x > 0)
                    {
                        rb.velocity = new Vector2(jumpX, jumpY);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-jumpX, jumpY);
                    }
            }
            else
            {
                Debug.Log("teste");
            }           
    }
    private void OnCollisionEnter2D(Collision2D other)
    {    
        if (other.gameObject.tag == "wall")
        {
            GameObject effectObj = Instantiate(wallBounceEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
            gameManagerScript.ChangeBackgroundColor();
            gameManagerScript.AddScore();
        }
        if (other.gameObject.tag == "triangle" && isDead == false)
        {
            isDead = true;
            isPlay = false;
            GameObject effectObj = Instantiate(deadEffectObj, other.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);

            gameManagerScript.GameOver();
           //StartCoroutine(cameraShake.Shake(0.1f, 0.3f));
            
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            gameObject.SetActive(false);

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            gameManagerScript.AddCoins();
            Destroy(collision.gameObject);
            Debug.Log("collect");
        }
    }
}
