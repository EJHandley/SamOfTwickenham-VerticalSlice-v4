using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    Camera cam;

    public CharacterStats stats;

    public Transform attackPoint;

    public Image healthBar;
    public Image energyBar;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition - cam.WorldToScreenPoint(attackPoint.position);
        Debug.DrawRay(attackPoint.position, mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, mousePosition);

            if (hit && hit.collider.tag == "Enemy")
            {
                CharacterStats target = hit.transform.GetComponent<CharacterStats>();
                print(hit.collider.name);
                BasicAttack(target);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SecondaryAttack();
        }
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        int damage = stats.basicDmg.GetValue();
        int range = stats.basicRange.GetValue();

        float distanceToEnemy = Vector2.Distance(attackPoint.position, targetStats.transform.position);

        if(distanceToEnemy <= range)
        {
            targetStats.TakeDamage(damage);
            print("Attack for " + damage);
        }
    }

    public void SecondaryAttack()
    {
        int damage = stats.secondDmg.GetValue();

        stats.TakeDamage(damage);
        print("Attack for" + damage);
    }

    public void UseEnergy(float amount)
    {

    }

    public void EnergyRegen()
    {

    }
}
