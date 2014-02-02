using System;

namespace MonoBoss.MSC
{

	/*
	 * An indirect value.  A value may be available trivially (without any computation), or it may involve a complex calculation
	 * to produce.  The value may also be <em>time-sensitive</em>, such that it is only available under certain circumstances
	 * (e.g. when the corresponding service is "up").
	 */ 

	public interface Value<T>
	{
		T getValue();
	}
}

