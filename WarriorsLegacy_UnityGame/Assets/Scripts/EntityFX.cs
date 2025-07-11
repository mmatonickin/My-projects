using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    [SerializeField] private Material originalMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }
    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(flashDuration);

        sr.material = originalMat;
    }
}
