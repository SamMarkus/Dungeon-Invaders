// Script provided by BMo's 2D Top Down Unity Movement tutorial
// Mouse pointer + weapon parent functions by Sunny Valley Studios

using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [Header("References")]
    public Health health;
    public Rigidbody2D rigidBody;
    public UIManager ui;
    [SerializeField] private InputActionReference pointerPosition, attack;
    private WeaponParent weaponParent;
    public SceneTransitionManager scene;
    public SaveDataManager save;

    [Header("Attributes")]
    public float moveSpeed;
    public float invincibleTimer = 1.5f;

    [Header("Variables")]
    private Vector2 moveDirection;
    private Vector2 pointerInput;
    private int totalMoney = 0;
    protected bool invincibility = false;
    protected bool spaceDelay = false; 

    private void Awake()
    {
        // Get weapon parent component
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    private void Start()
    {
        ui.SetHealthText(health.GetHealth());
    }

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;

        ProcessInputs();
        EscapeToMenu();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void MoveTo(Vector2 pos)
    {
        transform.position = pos;
        Invincible();
    }

    public void AddDollarToTotal(int dollar)
    {
        totalMoney += dollar;
        ui.SetMoneyText(totalMoney);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !(invincibility))
        {
            health.AddHealth(-1);
            ui.SetHealthText(health.GetHealth());
            if (health.GetHealth() == 0)
            {
                GameOver();
            }
            Invincible();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            ui.EnableSpaceText();
            if (Input.GetKey(KeyCode.Space) && !(spaceDelay))
            {
                StartSpaceDelay();
                collision.gameObject.GetComponent<ExitBehvaior>().ExitTriggered();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
            ui.DisableSpaceText();
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        weaponParent.Attack();
    }

    public void GameOver()
    {
        save.SetMoney(totalMoney);
        scene.LoadGameOver();
    }

    private void EscapeToMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameOver();
        }
    }

    public IEnumerator InvincibileTimer()
    {
        yield return new WaitForSeconds(invincibleTimer);
        invincibility = false;
    }

    public void Invincible()
    {
        invincibility = true;
        StartCoroutine(InvincibileTimer());
    }

    public IEnumerator SpaceDelayTimer()
    {
        yield return new WaitForSeconds(0.1f);
        spaceDelay = false;
        ui.DisableSpaceText();
    }

    public void StartSpaceDelay()
    {
        spaceDelay = true;
        StartCoroutine(SpaceDelayTimer());
    }
}
