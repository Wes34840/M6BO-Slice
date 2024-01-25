using UnityEngine;

public class KillBarrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<EntityHitbox>().TakeDamage(GetComponent<WeaponStats>());
    }
}
