using UnityEngine;

public class SkillFireBender : Skill
{
    [SerializeField] GameObject fireBallPrefab; // Pr�fabriqu� de la boule de feu
    [SerializeField] float fireBallSpeed = 10f; // Vitesse de la boule de feu

    // Fonction pour tirer la boule de feu
    public void Fire(Transform skillTransform)
    {
        // Instancier une boule de feu � partir du pr�fabriqu�
        GameObject fireBall = Instantiate(fireBallPrefab, skillTransform.position, Quaternion.identity);

        // R�cup�rer le rigidbody de la boule de feu
        Rigidbody rb = fireBall.GetComponent<Rigidbody>();

        // V�rifier si le rigidbody existe
        if (rb != null)
        {
            // Appliquer une force � la boule de feu pour la faire avancer en ligne droite
            rb.velocity = skillTransform.forward * fireBallSpeed;
        }
        else
        {
            Debug.LogError("Le pr�fabriqu� de la boule de feu ne contient pas de Rigidbody.");
        }
    }
}
