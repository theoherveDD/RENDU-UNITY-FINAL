using UnityEngine;

public class RedStrobe : MonoBehaviour
{
    // Intervalle du strobe en secondes.
    public float strobeInterval = 0.1f;
    // Couleur du strobe.
    private Color strobeColor = Color.red;

    // Composants attachés.
    private Light pointLight = null;
    private Renderer rend = null;

    // Timer pour gérer l'intervalle de strobe.
    private float strobeTimer = 0;

    void Start()
    {
        // Init des composants attachés.
        pointLight = GetComponent<Light>();
        rend = GetComponent<Renderer>();

        // Initialiser la lumière en rouge.
        if (pointLight != null)
        {
            pointLight.color = strobeColor;
        }

        // Initialiser le matériau en rouge.
        if (rend != null)
        {
            Material mat = rend.material;
            mat.SetColor("_EmissionColor", strobeColor);
        }
    }

    void Update()
    {
        // Mettre à jour le timer.
        strobeTimer += Time.deltaTime;

        // Si le timer dépasse l'intervalle, basculer l'état de la lumière.
        if (strobeTimer >= strobeInterval)
        {
            // Basculer la lumière.
            if (pointLight != null)
            {
                pointLight.enabled = !pointLight.enabled;
            }

            // Basculer l'émission du matériau.
            if (rend != null)
            {
                Material mat = rend.material;
                if (pointLight.enabled)
                {
                    mat.SetColor("_EmissionColor", strobeColor);
                }
                else
                {
                    mat.SetColor("_EmissionColor", Color.black);
                }
            }

            // Réinitialiser le timer.
            strobeTimer = 0;
        }
    }
}
