using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Playlist", menuName = "Playlist")]
public class PlaylistObject : ScriptableObject {


    [System.Serializable]
    public class Song
    {
        public string name;
        public AudioClip song;

        public Song(string newName, AudioClip clip)
        {
            name = newName;
            song = clip;
        }

    }

    public List<Song> list;

    public void Remove(int index)
    {
        list.RemoveAt(index);
    }

}
[CustomEditor(typeof(PlaylistObject))]
public class PlaylistObjectEditor : Editor
{
    PlaylistObject t;
    SerializedObject getTarget;
    SerializedProperty playlist;
    int listSize;

    void OnEnable()
    {
        t = (PlaylistObject)target;
        getTarget = new SerializedObject(t);
        playlist = getTarget.FindProperty("list");
    }

    override public void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        listSize = playlist.arraySize;
        listSize = EditorGUILayout.IntField("Size", listSize);

        if(listSize != playlist.arraySize)
        {
            while(listSize > playlist.arraySize)
            {
                playlist.InsertArrayElementAtIndex(playlist.arraySize);
            }
            while(listSize < playlist.arraySize)
            {
                playlist.DeleteArrayElementAtIndex(playlist.arraySize - 1);
            }
        }

        for (int i = 0; i < playlist.arraySize; i++)
        {
            SerializedProperty listRef = playlist.GetArrayElementAtIndex(i);
            SerializedProperty song = listRef.FindPropertyRelative("song");
            SerializedProperty name = listRef.FindPropertyRelative("name");

            GUILayout.BeginVertical("BOX");
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 60f;
            EditorGUILayout.PropertyField(name);
            EditorGUILayout.PropertyField(song);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Remove"))
            {
                playlist.DeleteArrayElementAtIndex(i);
                t.Remove(i);
            }
            GUILayout.EndVertical();
        }

    }
}
