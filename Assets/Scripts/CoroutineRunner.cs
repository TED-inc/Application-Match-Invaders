using UnityEngine;

public sealed class CoroutineRunner : MonoBehaviour
{
    public static CoroutineRunner instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
}
