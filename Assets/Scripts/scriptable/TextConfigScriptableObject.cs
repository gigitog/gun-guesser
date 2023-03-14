using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TextConfigScriptableObject", order = 1)]
public class TextConfigScriptableObject : ScriptableObject
{
    [Header("Weapon Typing")] 
    [SerializeField] private List<TypeToString> types;
    [Header("Weapon Classification")] 
    [SerializeField] private List<ClassificationToString> classifications;

    [Header("Errors")] [SerializeField]
    private string errorText;

    
    public string GetType(WeaponTyping searchedTyping)
    {
        foreach (var typing in types)
        {
            if (typing.typing == searchedTyping)
            {
                return typing.typingText;
            }
        }

        return errorText;
    }
    public string GetLongType(WeaponTyping searchedTyping)
    {
        foreach (var typing in types)
        {
            if (typing.typing == searchedTyping)
            {
                return typing.typingTextLong;
            }
        }

        return errorText;
    }

    public string GetClassification(WeaponClassification searchedClassification)
    {
        foreach (var classification in classifications)
        {
            if (classification.classification == searchedClassification)
            {
                return classification.classificationText;
            }
        }

        return errorText;
    }
}

[Serializable]
public class TypeToString
{
    public WeaponTyping typing;
    public string typingText;
    public string typingTextLong;
}

[Serializable]
public class ClassificationToString
{
    public WeaponClassification classification;
    public string classificationText;
}
