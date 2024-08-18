using UnityEngine;

public class Barometer : MonoBehaviour
{
    [SerializeField] float minAcceptanceAngle = -150.0f, maxAcceptanceAngle = -60.0f;

    void Update()
    {
        this.transform.Rotate(new Vector3(0.0f, 0.0f, 40.0f * Time.deltaTime));
        if (!Input.GetKey(KeyCode.Space))
            return;

        if (this.transform.rotation.z < this.minAcceptanceAngle / 360.0f || this.transform.rotation.z > this.maxAcceptanceAngle / 360.0f)
            return;

        Debug.Log("Space pressed");
    }
}