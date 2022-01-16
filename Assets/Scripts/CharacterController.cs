using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    Camera cam;

    public CharacterStats stats;

    public Transform attackPoint;
    public CharacterStats myTarget;

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

        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, mousePosition);

        if (hit && hit.collider.tag == "Enemy")
        {
            myTarget = hit.transform.GetComponent<CharacterStats>();
            print(hit.collider.name);
        }
        else
        {
            myTarget = null;
        }



        if(Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        int damage = stats.baseDamage.GetValue();
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
        int damage = stats.baseDamage.GetValue();

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
