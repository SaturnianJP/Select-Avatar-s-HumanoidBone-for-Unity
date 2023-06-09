using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoneSelect : MonoBehaviour
{
    [MenuItem("GameObject/Select HumanoidBone", false, 0)]
    static void Init()
    {
        GameObject Avatar = Selection.activeGameObject;
        if (Avatar == null)
            return;

        Animator _Animator = Avatar.GetComponent<Animator>();
        if (_Animator == null)
            return;

        Transform[] Bones = new Transform[(int)HumanBodyBones.LastBone];
        for (int i = 0; i < (int)HumanBodyBones.LastBone; i++)
        {
            Transform bone = _Animator.GetBoneTransform((HumanBodyBones)i);
            if (bone == null)
                continue;

            Bones[i] = bone;
        }

        List<GameObject> SelectGameObjects = new List<GameObject>();
        foreach (Transform bn in Bones)
        {
            if (bn == null)
                continue;

            SelectGameObjects.Add(bn.gameObject);
        }

        if (SelectGameObjects.Count > 0)
            Selection.objects = SelectGameObjects.ToArray();

    }
}
