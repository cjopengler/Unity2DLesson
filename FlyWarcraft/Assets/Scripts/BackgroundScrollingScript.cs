using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/**
 * 背景滚动脚本 背景进行无线的循环滚动
 * */
public class BackgroundScrollingScript : ScrollingScript {

	//背景是否无限循环
	public bool isLooping = false;

	private List<Transform> backgroundParts;


	// Use this for initialization
	void Start () {

		if (isLooping) {
			backgroundParts = new List<Transform>();

			for (int i = 0; i < transform.childCount; i++) {
				Transform child = transform.GetChild(i);

				//仅仅添加可见的child
				if (child.renderer != null) {
					backgroundParts.Add(child);
				}
			}

			//按照位置重新排序背景图片
			backgroundParts = backgroundParts.OrderBy( t => t.position.y).ToList();

		}
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

	
		if (isLooping) {
			Transform firstChild = backgroundParts.FirstOrDefault();

			if (firstChild != null) {
				if (firstChild.position.y < Camera.main.transform.position.y) {
					if (!firstChild.renderer.isVisibleFrom(Camera.main)) {

						Transform lastChild = backgroundParts.LastOrDefault();

						Vector3 lastPosition = lastChild.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

						//将firstChild坐标位置紧挨着lastChild放置

						firstChild.position = new Vector3(firstChild.position.x,
						                                  lastPosition.y + lastSize.y,
						                                  firstChild.position.z);

						//将first放置链表尾部
						backgroundParts.Remove(firstChild);
						backgroundParts.Add(firstChild);
					}
				}
			}
		}
	}
}
