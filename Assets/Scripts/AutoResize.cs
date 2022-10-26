using UnityEngine;

public class AutoResize : MonoBehaviour
{
    public Camera cam;
    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        //�������������ǰ��������
        Vector3 vec1 = canvas.transform.position - cam.transform.position;
        Vector3 vec2 = Vector3.Project(vec1, cam.transform.forward);
        canvas.transform.position = cam.transform.position + vec2;

        //���㻭���Ŀ��
        float planeDistance = Vector3.Distance(cam.transform.position, canvas.transform.position);
        float camHeight;
        float camWidth;
        if (cam.orthographic)
        {
            camHeight = cam.orthographicSize * 2.0f;
            camWidth = camHeight * cam.aspect;
        }
        else
        {
            camHeight = 2.0f * planeDistance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
            camWidth = camHeight * cam.aspect;
        }

        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(camWidth, camHeight);
    }
}