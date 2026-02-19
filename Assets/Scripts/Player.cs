using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float _hp;
    void Start()
    {
        _hp = 10f;
    }
}
