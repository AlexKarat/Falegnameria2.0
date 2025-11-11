using UnityEngine;

public class SegaController : MonoBehaviour
{
    public float topY = 3.5f;
    public float bottomY = -1f;
    public float speed = 2f;

    private bool goingDown = true;

    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 pos = transform.position;

        if (goingDown)
        {
            pos.y -= step;
            if (pos.y <= bottomY) goingDown = false;
        }
        else
        {
            pos.y += step;
            if (pos.y >= topY) goingDown = true;
        }

        transform.position = pos;
    }
}
