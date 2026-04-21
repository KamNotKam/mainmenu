using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPos;
    private bool keKanan = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = speed * Time.deltaTime;

        if (keKanan)
        {
            transform.position += new Vector3(move, 0, 0);

            if (transform.position.x >= startPos.x + distance)
                keKanan = false;
        }
        else
        {
            transform.position += new Vector3(-move, 0, 0);

            if (transform.position.x <= startPos.x - distance)
                keKanan = true;
        }
    }
}