using UnityEngine;
using System.Collections;

public static class RenderExtensionScript {

	public static bool isVisibleFrom(this Renderer renderer, Camera camera) {

		//获取照相机的投影平面的所有面
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

		//进行AABB测试
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
