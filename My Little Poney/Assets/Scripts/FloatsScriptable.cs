using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Floats Data", menuName = "ScriptableObjects/floats")]
public class FloatsScriptable : ScriptableObject
{
    public float m_information;

    public void SetValue(float value)
    {
        m_information = value;
    }
}
