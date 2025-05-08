using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public float patrolDistance = 3f;
    
    [Header("Components")]
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float startingX;
    private bool movingRight = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        startingX = transform.position.x;
    }

    void Update()
    {
        // Calcul du mouvement
        float moveDirection = movingRight ? 1 : -1;
        float newX = transform.position.x + moveDirection * speed * Time.deltaTime;

        // Vérification des limites
        if (Mathf.Abs(newX - startingX) >= patrolDistance)
        {
            movingRight = !movingRight;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // Application du mouvement
        transform.position = new Vector2(newX, transform.position.y);

        // Contrôle de l'animation
        animator.SetFloat("moveSpeed", Mathf.Abs(speed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Vérifie si le joueur vient du dessus (normal.y < 0)
            if (collision.contacts[0].normal.y < -0.5f)
            {
                PlayerPrefs.SetInt("MobDestroyed", 1);
                Destroy(gameObject);
            }
            else
            {
                // Ici, faites des dégâts au joueur
                Debug.Log("Player touché!");
            }
        }
    }
}