using System.Collections;
using UnityEditor;
using UnityEngine;

public class EditorTool : Editor
{
    /// <summary>
    /// 以第一个物体为基准，选中后面有多少物体就复制多少个物体，并把位置、旋转、大小也复制上去
    /// </summary>
    [MenuItem("工具/复制物体")]
    public static void FixedCopyGOs()
    {
        Object[] objArr = Selection.objects;
        if (objArr.Length >= 2)
        {
            GameObject preGo = objArr[0] as GameObject;
            string objName = objArr[0].name;
            for (int i = 1; i < objArr.Length; i++)
            {
                GameObject go = Instantiate(preGo, preGo.transform.parent);
                go.name = string.Format("{0}_{1}", objName, i);
                GameObject tar = objArr[i] as GameObject;
                go.transform.position = tar.transform.position;
                go.transform.eulerAngles = tar.transform.eulerAngles;
                go.transform.localScale = tar.transform.localScale;
            }
            for (int i = 1; i < objArr.Length; i++)
            {
                // Destroy(objArr[i]);
            }
        }
    }

    /// <summary>
    /// 复制transform内的数据
    /// </summary>
    [MenuItem("工具/复制Transform的数据给后面的物体")]
    public static void FixedCopyTransformData()
    {
        Object[] objArr = Selection.objects;
        if (objArr.Length >= 2)
        {
            int startIndex = objArr.Length / 2;
            for (int i = 0; i < startIndex; i++)
            {
                GameObject go1 = objArr[i] as GameObject;
                GameObject go2 = objArr[i + startIndex] as GameObject;
                go2.transform.position = go1.transform.position;
                go2.transform.localScale = go1.transform.localScale;
                go2.transform.eulerAngles = go1.transform.eulerAngles;
            }
            Debug.Log("复制数据完成");
        }
    }
}