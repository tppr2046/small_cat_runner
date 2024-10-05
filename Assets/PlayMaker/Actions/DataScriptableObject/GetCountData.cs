using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("DataScriptableObject")]
	[Tooltip("Custom action. Gets the value of DataScriptableObject.")]
	public class GetCountData : FsmStateAction
	{
		[Tooltip("Index of the Data")]
		public FsmInt dataIndex;


		[UIHint(UIHint.Variable)]
		[Tooltip("Time Stamp to Get")]
		public FsmString timeStamp;

		[UIHint(UIHint.Variable)]
		[Tooltip("Result to Get")]
		public FsmBool win;

		[UIHint(UIHint.Variable)]
		[Tooltip("Score to Get")]
		public FsmInt score;


		[ObjectType(typeof(DataScriptableObject))]
		public FsmObject ItemReference;


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var Item = ItemReference.Value;
			DataScriptableObject ourItem = Item as DataScriptableObject;
			var index = dataIndex.Value;
			var countingList = ourItem.countingdata;


			timeStamp.Value = countingList[index].timeStamp;
			win.Value = countingList[index].win;
			score.Value = countingList[index].score;



			Finish();

		}

	}


}


