﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using static _INTERNAL_.Scripts.Utilities.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(Move))]
public class MoveInspector : InspectorBase
{
	private string explanation = _("The GameObject moves when pressing specific keys. Choose between Arrows or WASD.");
	private string constraintsReminder = _("If you want, you can constrain movement on the X/Y axes in the Rigidbody2D's properties.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//base.OnInspectorGUI();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("typeOfControl"));

		EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("movementType"));

		GUILayout.Space(5);
		GUILayout.Label(_("Orientation"), EditorStyles.boldLabel);
		bool orientToDirectionTemp = EditorGUILayout.Toggle(_("Orient to direction"), serializedObject.FindProperty("orientToDirection").boolValue);
		if(orientToDirectionTemp)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("lookAxis"));
		}
		serializedObject.FindProperty("orientToDirection").boolValue = orientToDirectionTemp;


		if(serializedObject.FindProperty("movementType").intValue != 0)
		{
			EditorGUILayout.HelpBox(constraintsReminder, MessageType.Info);
		}

		serializedObject.ApplyModifiedProperties();
	}
}