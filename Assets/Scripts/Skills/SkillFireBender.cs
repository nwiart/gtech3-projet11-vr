using UnityEngine;

public class SkillFireBender : Skill
{
    [SerializeField] GameObject fireBallPrefab; // Préfabriqué de la boule de feu
    [SerializeField] float fireBallSpeed = 10f; // Vitesse de la boule de feu

    // Fonction pour tirer la boule de feu
    public void Fire(Transform skillTransform)
    {
        // Instancier une boule de feu à partir du préfabriqué
        GameObject fireBall = Instantiate(fireBallPrefab, skillTransform.position, Quaternion.identity);

        // Récupérer le rigidbody de la boule de feu
        Rigidbody rb = fireBall.GetComponent<Rigidbody>();

        // Vérifier si le rigidbody existe
        if (rb != null)
        {
            // Appliquer une force à la boule de feu pour la faire avancer en ligne droite
            rb.velocity = skillTransform.forward * fireBallSpeed;
        }
        else
        {
            Debug.LogError("Le préfabriqué de la boule de feu ne contient pas de Rigidbody.");
        }
    }
}
