using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpellInputController _leftHand;

    [SerializeField]
    private SpellInputController _rightHand;

    [SerializeField]
    private XRRayInteractor _leftRayInteractor;

    [SerializeField]
    private XRRayInteractor _rightRayInteractor;

    [SerializeField]
    private bool _canMove = true;


    public SpellInputController LeftHand => _leftHand;
    public SpellInputController RightHand => _rightHand;


    private List<Skill> _skills = new List<Skill>();

    public List<Skill> Skills => _skills;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UnlockSkill(Skill skillSO)
    {
        Skill skillInst = Instantiate(skillSO);
        _skills.Add(skillInst);

        skillInst.OnUnlock(this);
    }

    public void SetRayInteractorsEnabled(bool enabled)
    {
        _leftRayInteractor.gameObject.SetActive(enabled);
        _rightRayInteractor.gameObject.SetActive(enabled);
    }
}
