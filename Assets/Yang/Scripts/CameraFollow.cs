using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("要跟随的目标（通常是玩家）")]
    public Transform target;

    // 
    [Header("相机与目标之间的偏移量")]
    public Vector3 offset = new Vector3(0, 0, -10);

    // 
    //[Header("平滑因子，值越大越快跟随")]
    private float smoothSpeed = 20f;

    /*// 
    [Header("相机边界限制")]
    public Vector2 minPosition;
    public Vector2 maxPosition;*/

    private void LateUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        // 计算目标位置
        Vector3 desiredPosition = target.position + offset;

     /*   // 应用边界限制（如果设置了）
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);*/

        // 平滑移动到目标位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 设置相机位置
        transform.position = smoothedPosition;
    }

    // 可选：允许外部设置目标
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}