
using System;
using System.Collections.Generic;

namespace Glide
{
	public class AutoLerp<T> : Lerper where T : struct
	{
		//	static constructors on generic classes run once per subtype, yay!
		static AutoLerp()
		{
			properties = new List<string>();
			var fields = typeof(T).GetFields();
			var props = typeof(T).GetProperties();
			
			for (int i = 0; i < fields.Length; ++i)
			{
				if (IsNumeric(fields[i].FieldType))
					properties.Add(fields[i].Name);
			}
			
			for (int i = 0; i < props.Length; ++i)
			{
				if (IsNumeric(props[i].PropertyType))
					properties.Add(props[i].Name);
			}
			
		}
		
		private static bool IsNumeric(Type type)
		{
			return
				type == typeof(Int32) ||
				type == typeof(Single) ||
				type == typeof(Int16) ||
				type == typeof(Int64) ||
				type == typeof(UInt16) ||
				type == typeof(UInt32) ||
				type == typeof(UInt64) ||
				type == typeof(Double);
		}
		
		private static List<string> properties;
		private float[] from, to, range;
		private GlideInfo[] info;
		private Type[] types;
		private object result;	//	boxed version of T
		
		public AutoLerp()
		{
			result = (object) new T();
			from = new float[properties.Count];
			to = new float[properties.Count];
			range = new float[properties.Count];
			info = new GlideInfo[properties.Count];
			types = new Type[properties.Count];
		}
		
		public override void Initialize(object fromValue, object toValue, Lerper.Behavior behavior)
		{
			for (int i = 0; i < properties.Count; i++)
			{
				var name = properties[i];
				info[i] = new GlideInfo(result, name);
				types[i] = info[i].Value.GetType();
				from[i] = Convert.ToSingle(GlideInfo.GetValue(fromValue, name));
				to[i] = Convert.ToSingle(GlideInfo.GetValue(toValue, name));
				range[i] = to[i] - from[i];
			}
		}
		
		public override object Interpolate(float t, object currentValue, Lerper.Behavior behavior)
		{
			for (int i = 0; i < properties.Count; i++)
			{
				var v = from[i] + range[i] * t;
				if (behavior.HasFlag(Behavior.Round))
					v = (float) Math.Round(v);
				
				info[i].Value = Convert.ChangeType(v, types[i]);
			}
			
			return result;
		}
	}
}
