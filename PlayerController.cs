using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float jumpForce = 200f;

    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    // 아이템 기록
    public Dictionary<string, int> itemCounts = new Dictionary<string, int>();
    public int totalItemsPickedUp = 0;

    // ⭐ 시작 위치 저장
    Vector3 startPosition;

    // ------------------------------

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // ⭐ 시작 위치 기억
            startPosition = transform.position;

            // 씬 로드될 때마다 호출
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ⭐ 씬 다시 로드되면 항상 여기로 이동
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJump", true);
        }

        if (rb.linearVelocity.x > 0)
        {
            animator.SetBool("isMove", true);
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x < 0)
        {
            animator.SetBool("isMove", true);
            sr.flipX = false;
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }
    }

    public void PickUpItem(string itemName)
    {
        totalItemsPickedUp++;

        if (itemCounts.ContainsKey(itemName))
            itemCounts[itemName]++;
        else
            itemCounts.Add(itemName, 1);

        Debug.Log("아이템 획득: " + itemName);
    }
    public void ResetItems()
    {
    itemCounts.Clear();
    totalItemsPickedUp = 0;

    Debug.Log("아이템 초기화 완료");
    }

}
