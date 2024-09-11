using UnityEngine;

public class CharacterLookAtCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = worldMousePos - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float step = 5f * Time.deltaTime; 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }

    }
}
