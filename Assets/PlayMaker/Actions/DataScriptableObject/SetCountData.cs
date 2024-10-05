using UnityEngine;
using System;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("DataScriptableObject")]
	[Tooltip("Custom action. Sets the value of DataScriptableObject.")]
	public class SetCountData : FsmStateAction
	{
		[ObjectType(typeof(DataScriptableObject))]
		public FsmObject ItemReference;

		[UIHint(UIHint.Variable)]
		[Tooltip("Index of the Data")]
		public FsmInt dataIndex;

		[Tooltip("Time Stamp to Auto set")]
		public FsmString timeStamp;
		public FsmString format;

		[Tooltip("Result to set")]
		public FsmBool win;

		[Tooltip("Score to Set")]
		public FsmInt score;




		public override void Reset()
		{
			timeStamp = null;
			format = "yyyyMMddHHmmss";
		}

		public void AddData(string timeStamp, bool win, int score)
		{
			var Item = ItemReference.Value;
			DataScriptableObject ourItem = Item as DataScriptableObject;

			// 創建一個新的 CountingData 實例
			DataScriptableObject.CountingData newData = new DataScriptableObject.CountingData
			{
				timeStamp = timeStamp,
				win = win,
				score = score
			};

			// 新增該實例到 ScriptableObject 的列表中
			ourItem.countingdata.Add(newData);

			// 如果需要，這裡可以保存修改（例如在編輯器中）


			Debug.Log("新數據已新增到 ScriptableObject 中");
		}


		public override void OnEnter()
		{

			var Item = ItemReference.Value;
			DataScriptableObject ourItem = Item as DataScriptableObject;
			var countingList = ourItem.countingdata;
			var index = countingList.Count;
			dataIndex.Value = index;
			timeStamp.Value = DateTime.Now.ToString(format.Value);
			AddData(timeStamp.Value, win.Value, score.Value);



			Finish();

		}






	}

}
