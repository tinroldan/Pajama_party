using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class faceOBJ
{
    public Mesh m_mesh;
    public Material[] m_material;
}
[System.Serializable]

public class bodyOBJ
{
    public Mesh m_mesh;
    public Material[] m_material;
}
[System.Serializable]

public class tailOBJ
{
    public Mesh m_mesh;
    public Material[] m_material;
}

public class SkinManager : MonoBehaviour
{
    [SerializeField] Online_skin m_skin;

    [SerializeField] SkinnedMeshRenderer m_meshRend_face;
    [SerializeField] SkinnedMeshRenderer m_meshRend_body;
    [SerializeField] SkinnedMeshRenderer m_meshRend_tail;

    [SerializeField] faceOBJ[] m_faceList;
    [SerializeField] bodyOBJ[] m_bodyList;
    [SerializeField] tailOBJ[] m_tailList;

    void Start()
    {
        m_meshRend_face.sharedMesh = (m_faceList[m_skin.face].m_mesh);
        m_meshRend_body.sharedMesh = (m_bodyList[m_skin.pijama].m_mesh);
        m_meshRend_tail.sharedMesh = (m_tailList[m_skin.face].m_mesh);

        m_meshRend_face.materials = (m_faceList[m_skin.face].m_material);
        m_meshRend_body.materials = (m_bodyList[m_skin.pijama].m_material);
        m_meshRend_tail.materials=(m_tailList[m_skin.face].m_material);
    }

    void Update()
    {
        m_meshRend_face.sharedMesh = (m_faceList[m_skin.face].m_mesh);
        m_meshRend_body.sharedMesh = (m_bodyList[m_skin.pijama].m_mesh);
        m_meshRend_tail.sharedMesh = (m_tailList[m_skin.face].m_mesh);

        m_meshRend_face.materials = (m_faceList[m_skin.face].m_material);
        m_meshRend_body.materials = (m_bodyList[m_skin.pijama].m_material);
        m_meshRend_tail.materials = (m_tailList[m_skin.face].m_material);
    }
}