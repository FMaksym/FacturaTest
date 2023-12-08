using System.Collections;
using UnityEngine;

public class CarVFX : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _dieParticle;
    [SerializeField] private ParticleSystem _smokeParticle;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private ParticleSystem _shootParticle;
    [SerializeField] private CarHealth _carHealth;

    private void OnEnable()
    {
        CarHealth.CarTakeDamage += FlashEffect;
        CarHealth.CarDie += CarDieEffect;
        CarHealth.CarHalfHealth += CarInSmoke;
        CarHealth.CarQuarterHealth += CarInFire;
    }

    private void FlashEffect()
    {
        float flashDuration = 0.25f;

        Color originalColor = _meshRenderer.material.GetColor("_EmissionColor");
        _meshRenderer.material.EnableKeyword("_EMISSION");
        _meshRenderer.material.SetColor("_EmissionColor", Color.white);

        StartCoroutine(RestoreMaterial(flashDuration, _meshRenderer.material, originalColor));
    }

    private void CarDieEffect()
    {
        _fireParticle.gameObject.SetActive(false);
        _dieParticle.gameObject.SetActive(true);
        _dieParticle.Play();

    }

    private IEnumerator RestoreMaterial(float flashDuration, Material material, Color originalColor)
    {
        yield return new WaitForSeconds(flashDuration);

        material.SetColor("_EmissionColor", originalColor);
        material.DisableKeyword("_EMISSION");
    }

    private void CarInSmoke()
    {
        _smokeParticle.gameObject.SetActive(true);
        _smokeParticle.Play();
    }

    private void CarInFire()
    {
        _smokeParticle.gameObject.SetActive(false);
        _smokeParticle.Stop();
        _fireParticle.gameObject.SetActive(true);
        _fireParticle.Play();
    }

    public void ShootTurret()
    {
        _shootParticle.gameObject.SetActive(true);
        _shootParticle.Play();
        StartCoroutine(DeactivatePartice(0.4f, _shootParticle));
    }

    private IEnumerator DeactivatePartice(float time, ParticleSystem particle)
    {
        yield return new WaitForSeconds(time);
        particle.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CarHealth.CarTakeDamage -= FlashEffect;
        CarHealth.CarDie -= CarDieEffect;
        CarHealth.CarHalfHealth -= CarInSmoke;
        CarHealth.CarQuarterHealth -= CarInFire;
    }
}
