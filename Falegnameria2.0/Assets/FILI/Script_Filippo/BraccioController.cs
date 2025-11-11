using UnityEngine;

public class BraccioController : MonoBehaviour
{
    [Header("Limiti orizzontali")]
    public float leftX = -4.5f;
    public float rightX = 4.5f;
    [Header("Velocità")]
    public float speed = 3f;

    private bool movingRight = true;
    private bool isMouseHeld = false;

    void Update()
    {
        // Se il progetto usa il New Input System + Both, Input.GetMouseButton va bene.
        isMouseHeld = Input.GetMouseButton(0);

        if (!isMouseHeld) return;

        float step = speed * Time.deltaTime;
        Vector3 pos = transform.position;

        if (movingRight)
        {
            pos.x += step;
            if (pos.x >= rightX) movingRight = false;
        }
        else
        {
            pos.x -= step;
            if (pos.x <= leftX) movingRight = true;
        }

        transform.position = pos;
    }
}
