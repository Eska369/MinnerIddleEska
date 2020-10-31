using UnityEngine;
using UnityEngine.UI;
public class Example : MonoBehaviour
{
    public Scrollbar scrollbar; // assign in the inspector
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Awake()
    {
        if (scrollbar != null)
        {
            scrollbar.onValueChanged.AddListener(onScroll);
        }
    }

    private void onScroll(float value)
    {
        transform.position = Vector2.Lerp(minPosition, maxPosition, value);
    }
}