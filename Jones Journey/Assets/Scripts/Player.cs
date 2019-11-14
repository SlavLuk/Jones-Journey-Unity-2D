using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
   [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveAmount;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount)
    {

        health -= damageAmount;
        UpdateHeartUI(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void UpdateHeartUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHeartUI(health);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weapon, transform.position, transform.rotation, transform);
    }
}
