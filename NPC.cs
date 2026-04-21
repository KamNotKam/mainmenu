using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector2 direction = target.position - transform.position;

        // 🔥 FIX 1: Atan2 harus (y, x)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 🔥 FIX 2: offset biar gak membelakangi
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
}