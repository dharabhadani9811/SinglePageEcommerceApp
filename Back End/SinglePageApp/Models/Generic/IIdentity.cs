using System;

namespace DharaProject.Models.Generic
{
	public interface IIdentity<T>
		where T : IComparable<T>
	{
		public T Id { get; protected set; }
	}
}
