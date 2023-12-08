using System.Collections;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private ParticleSystem _bloodParticle;

    private Material _originalMaterial;
    private EnemyHealth _enemyHealth;

    private void OnEnable()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        if (_enemyHealth != null)
        {
            _enemyHealth.EnemyTakeDamage += FlashEffect;
        }
    }

    private void Awake()
    {
        _originalMaterial = _skinnedMeshRenderer.material;
    }

    private void FlashEffect()
    {
        float flashDuration = 0.25f;

        Material materialCopy = new (_originalMaterial);

        _skinnedMeshRenderer.material = materialCopy;

        Color originalColor = materialCopy.GetColor("_EmissionColor");
        materialCopy.EnableKeyword("_EMISSION");
        materialCopy.SetColor("_EmissionColor", Color.white);

        _bloodParticle.gameObject.SetActive(true);
        _bloodParticle.Play();
        StartCoroutine(RestoreMaterial(flashDuration, originalColor, _skinnedMeshRenderer, materialCopy, _originalMaterial));
    }

    private IEnumerator RestoreMaterial(float flashDuration, Color originalColor, SkinnedMeshRenderer skinnedMeshRenderer, Material materialCopy, Material originalMaterial)
    {
        yield return new WaitForSeconds(flashDuration);

        materialCopy.SetColor("_EmissionColor", originalColor);
        materialCopy.DisableKeyword("_EMISSION");

        skinnedMeshRenderer.material = originalMaterial;
    }

    private void OnDisable()
    {
        _enemyHealth.EnemyTakeDamage -= FlashEffect;
    }
}
