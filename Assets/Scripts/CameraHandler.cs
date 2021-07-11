using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomAmount;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float minOrthographicSize;
    [SerializeField] private float maxOrthographicSize;
    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start()
    {
        orthographicSize = virtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y, 0).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void Zoom()
    {
        targetOrthographicSize += Input.mouseScrollDelta.y * zoomAmount;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        virtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
