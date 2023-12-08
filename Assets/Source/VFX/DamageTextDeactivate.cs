using UnityEngine;
using Zenject;

public class DamageTextDeactivate : MonoBehaviour
{
    [SerializeField] private float _time = 0.25f;

    [Inject] private Camera _playerCamera;

    private void OnEnable()
    {
        Invoke("InActive", _time);
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + _playerCamera.transform.forward);
    }

    private void InActive()
    {
        gameObject.SetActive(false);
    }
}
