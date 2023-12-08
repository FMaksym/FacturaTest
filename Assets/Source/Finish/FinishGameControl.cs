using UnityEngine;
using Zenject;

public class FinishGameControl : MonoBehaviour
{
    public delegate void FinishGameEventHandler();
    public static event FinishGameEventHandler FinishGame;

    [SerializeField] private float _finishRadius;

    private bool isPlayerInRange;

    [Inject] private GameManager _gameManager;

    private void Update()
    {
        FindPlayer();
        if (isPlayerInRange)
        {
            FinishGame?.Invoke();
            _gameManager.GameOver();
        }
    }

    private void FindPlayer()
    {
        isPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _finishRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<CarHealth>())
            {
                isPlayerInRange = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _finishRadius);
    }
}
