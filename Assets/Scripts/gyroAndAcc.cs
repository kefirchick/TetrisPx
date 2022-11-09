using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroAndAcc : MonoBehaviour
{
    Gyroscope m_Gyro;
    float xGravity;
    float yGravity;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            m_Gyro = Input.gyro;
            m_Gyro.enabled = true;
        }
    }

    void Update()
    {
        if (SystemInfo.supportsGyroscope && PlayerPrefs.GetInt("gyroPref", 0) == 1) 
        {
            xGravity = Input.gyro.gravity.x * 10;
            yGravity = Input.gyro.gravity.y * 10;
            Physics2D.gravity = new Vector2(xGravity, yGravity);
        }
    }
}
