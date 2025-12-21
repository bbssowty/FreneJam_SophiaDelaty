using System.Collections;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Animator animator;
    private float health;
    private float damage;
    private float speed;
    private float attackSpeed;

    private CurrentPlayer owner;
    private int direction;

    private bool canAttack = true;

    private UnitBehavior currentEnemy;

    public void Setup(UnitData unitData, CurrentPlayer owner ,float healthMultiplier, float damageMultiplier)
    {
        health = unitData.Health * healthMultiplier;
        damage = unitData.Damage * damageMultiplier;
        speed = unitData.Speed;
        attackSpeed = unitData.AttackSpeed;
        
        this.owner = owner;
    }

    private void Start()
    {
        // Example debug output to verify setup
        Debug.Log($"Unit spawned for {owner} with Health: {health}, Damage: {damage}, Speed: {speed}, AttackSpeed: {attackSpeed}");

        if (owner == CurrentPlayer.Player1)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        animator.SetBool("isWalking",  true);
        animator.SetBool("isFighting", false);
    }

    private void Update()
    {
        if (canAttack && currentEnemy == null)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        }
        else if (canAttack && currentEnemy != null)
        {
            Attack();
        }
    }

    private void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            if (collision.TryGetComponent<UnitBehavior>(out UnitBehavior unit))
            {
                if (unit.owner != this.owner)
                {
                    if (canAttack)
                    {
                        Debug.Log(this.name + " Attack " + unit.name + " with " + damage + " Damages");
                        currentEnemy = unit;
                        Attack();
                    }
                }
            }
        }
        if(collision.CompareTag("Tower"))
        {
            if (collision.TryGetComponent<TowerBehaviour>(out TowerBehaviour tower))
            {
                if (tower.GetOwner() != this.owner)
                {
                    if (canAttack)
                    {
                        tower.TakeDamage(health);
                        this.TakeDamage(health);
                        StartCoroutine(AttackCooldown());
                    }
                }
            }
        }
    }

    private void Attack()
    {
        currentEnemy.TakeDamage(damage);
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        animator.SetBool("isWalking", false); animator.SetBool("isFighting", true);
        yield return new WaitForSeconds(1f / attackSpeed);
        canAttack = true;
        animator.SetBool("isWalking", true); animator.SetBool("isFighting", false);
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}