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

			// �Ыؤ@�ӷs�� CountingData ���
			DataScriptableObject.CountingData newData = new DataScriptableObject.CountingData
			{
				timeStamp = timeStamp,
				win = win,
				score = score
			};

			// �s�W�ӹ�Ҩ� ScriptableObject ���C��
			ourItem.countingdata.Add(newData);

			// �p�G�ݭn�A�o�̥i�H�O�s�ק�]�Ҧp�b�s�边���^


			Debug.Log("�s�ƾڤw�s�W�� ScriptableObject ��");
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
