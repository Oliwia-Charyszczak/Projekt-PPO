using UnityEngine;

// Interface na si³e w sumie nie potrzbny
public interface IEnemyAction
{
    void PerformAction();
}

public class EnemyLogic : MonoBehaviour, IEnemyAction
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    [SerializeField] private float bounceForce = 3f;
    private Rigidbody2D rb;
    private Transform currentPoint;
    private CapsuleCollider2D collide;
    private BoxCollider2D collide1;
    private bool isInContactWithPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<CapsuleCollider2D>();
        collide1 = GetComponent<BoxCollider2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        if (!isInContactWithPlayer)
        {
            PerformAction();
        }
    }

    public void PerformAction()
    {
        MoveLogic();
    }

    private void MoveLogic()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.activeSelf)
        {
            isInContactWithPlayer = true;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInContactWithPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
            }

            gameObject.SetActive(false);
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
