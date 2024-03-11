using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShader : MonoBehaviour
{

    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private AnimationCurve _width;
    [SerializeField] private AnimationCurve _height;
    
    [ContextMenu("test")]
    public void Launch()
    {
        ParticleSystemRenderer pr = (ParticleSystemRenderer)_ps.GetComponent<Renderer>();
        VaryShaderPropertiesOverTime(pr);
    }
    
    private void VaryShaderPropertiesOverTime(ParticleSystemRenderer pr)
    {
        float elapsedTime = 0f;
        float duration = 2f; // Durée totale de la variation, ajustez selon vos besoins.

        while (elapsedTime < duration)
        {
            float normalizedTime = elapsedTime / duration;
            pr.material.SetFloat("_Width", _width.Evaluate(normalizedTime));
            pr.material.SetFloat("_Height", _height.Evaluate(normalizedTime));
            elapsedTime += Time.deltaTime;
        }
    }
}