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
    
    private IEnumerator VaryShaderPropertiesOverTime(ParticleSystemRenderer a)
    {
        float elapsedTime = 0f;
        float duration = 2f; // Durée totale de la variation, ajustez selon vos besoins.

        while (elapsedTime < duration)
        {
            float normalizedTime = elapsedTime / duration;
            a.material.SetFloat("_Width", _width.Evaluate(normalizedTime));
            a.material.SetFloat("_Height", _height.Evaluate(normalizedTime));
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        
        a.material.SetFloat("_Width", _width.Evaluate(1f));
        a.material.SetFloat("_Hidth", _height.Evaluate(1f));
    }
}
