using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShader : MonoBehaviour
{

    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private AnimationCurve _width;
    [SerializeField] private AnimationCurve _heigth;
    

    [ContextMenu("test")]
    public void Launch()
    {
        ParticleSystemRenderer pr = (ParticleSystemRenderer)_ps.GetComponent<Renderer>();
        //coroutine qui varie l'apaisseur et la loongueur du shader.
        
        pr.material.SetFloat("_Width", _width.Evaluate(0.5f));
        pr.material.SetFloat("_Width", _heigth.Evaluate(0.5f));
    }


}
