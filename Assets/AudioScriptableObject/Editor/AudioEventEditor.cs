﻿using UnityEditor;
using UnityEngine;

namespace AudioScriptableObject.Editor
{
	[CustomEditor(typeof(AudioEventBase), true)]
	public class AudioEventEditor : UnityEditor.Editor
	{
/* an audio source to preview on the fly */
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Preview"))
			{
				((AudioEventBase) target).Play(_previewer);
			}
			EditorGUI.EndDisabledGroup();
		}
	}
}
