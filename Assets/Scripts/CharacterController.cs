using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    Camera cam;

    public CharacterStats stats;

    public Transform attackPoint;
    public CharacterStats myTarget;
    public CharacterStats[] targetsInRange;

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
    }
}
