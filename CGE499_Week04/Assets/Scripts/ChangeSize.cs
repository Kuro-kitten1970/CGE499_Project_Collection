using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.increaseSizeEvent += IncreaseSize;
        EventManager.decreaseSizeEvent += DecreaseSize;
    }

    private void OnDisable()
    {
        EventManager.increaseSizeEvent -= IncreaseSize;
        EventManager.decreaseSizeEvent -= DecreaseSize;
    }

    private void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + 1.5f,
                                           transform.localScale.y + 1.5f,
                                           transform.localScale.z + 1.5f);
    }

    private void DecreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1.5f,
                                           transform.localScale.y - 1.5f,
                                           transform.localScale.z - 1.5f);
    }
}
