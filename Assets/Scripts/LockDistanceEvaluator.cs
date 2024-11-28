using UnityEngine;

public class LockDistanceEvaluator : MonoBehaviour
{
    public Transform lever; // Transform de la palanca
    public Transform lockMechanism; // Transform del seguro
    public MonoBehaviour lockScript; // Script espec�fico del seguro que se activar�/desactivar�
    public float lockDistanceThreshold = 0.1f; // Distancia m�nima para activar el script

    void Update()
    {
        // Evaluar la distancia local entre la palanca y el seguro
        EvaluateLockDistance();
    }

    private void EvaluateLockDistance()
    {
        // Calcular la distancia entre la palanca y el seguro en espacio local
        float distance = Vector3.Distance(lever.localPosition, lockMechanism.localPosition);

        // Activar o desactivar el script seg�n la distancia
        if (distance > lockDistanceThreshold)
        {
            if (!lockScript.enabled)
            {
                lockScript.enabled = true;
                Debug.Log("El seguro est� lejos: Script activado.");
            }
        }
        else
        {
            if (lockScript.enabled)
            {
                lockScript.enabled = false;
                Debug.Log("El seguro est� cerca: Script desactivado.");
            }
        }
    }
}
