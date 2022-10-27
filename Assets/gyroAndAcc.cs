using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroAndAcc : MonoBehaviour
{
    Gyroscope m_Gyro;
    float zAngle;
    float xGravity;
    float yGravity;

    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    void Update()
    {
        zAngle = (Input.gyro.attitude.eulerAngles.z - 90) * Mathf.PI / 180;
        xGravity = -10f * Mathf.Sin(zAngle);
        yGravity = -10f * Mathf.Cos(zAngle);
        Physics2D.gravity = new Vector2(xGravity, yGravity);
        Debug.Log($"{Input.gyro.attitude.eulerAngles.z}    {zAngle}    {xGravity}    {yGravity}");
        // transform.eulerAngles = new Vector3(0, 0, -zAngle - 90);
    }
}
