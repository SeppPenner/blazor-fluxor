﻿using Microsoft.AspNetCore.Components;
using System;

namespace Blazor.Fluxor
{
	/// <summary>
	/// Identifies a self-contained sub-section of state within the store.
	/// </summary>
	public interface IFeature
	{
		/// <summary>
		/// The unique name to use for this feature when building up the composite state. E.g. if this returns "Cart" then
		/// the composite state returned would contain a property "Cart" with a value that represents the contents of State.
		/// </summary>
		/// <returns>The unique name of the feature</returns>
		string GetName();

		/// <summary>
		/// The current state of the feature
		/// </summary>
		/// <returns>The current state of the feature</returns>
		object GetState();

		/// <summary>
		/// Identifies which class type the state should be. This is useful for
		/// operations that need to know the type even when the state is null,
		/// such as deserialization.
		/// </summary>
		/// <returns>The type of the state that the feature works with</returns>
		Type GetStateType();

		/// <summary>
		/// Sets the current state of the feature. This should only be used by Middleware, not for mutating
		/// state within an application.
		/// </summary>
		/// <seealso cref="IMiddleware"/>
		/// <param name="value">The value of the state to set as the feature's current state</param>
		void RestoreState(object value);

		/// <summary>
		/// Allows a feature to react to an action dispatched via the store. This should not be called by
		/// consuming applications. Instead you should dispatch actions only via <see cref="IDispatcher.Dispatch(object)"/>
		/// </summary>
		/// <param name="action">The action dispatched via the store</param>
		void ReceiveDispatchNotificationFromStore(object action);

		/// <summary>
		/// Registers a component to be re-rendered whenever the state changes
		/// </summary>
		/// <param name="subscriber">The component that will have <see cref="ComponentBase.StateHasChanged"/> executed when the state changes</param>
		void Subscribe(ComponentBase subscriber);
	}

	/// <summary>
	/// A type-safe implementation of <see cref="IFeature"/>
	/// </summary>
	/// <typeparam name="TState">The type of the state this feature owns</typeparam>
	public interface IFeature<TState> : IFeature
	{
		/// <summary>
		/// The current state of the feature
		/// </summary>
		TState State { get; }

		/// <summary>
		/// Adds an instance of a reducer to this feature
		/// </summary>
		/// <param name="reducer">The reducer instance</param>
		/// <seealso cref="DependencyInjection.Options.UseDependencyInjection(System.Reflection.Assembly[])"/>
		void AddReducer(IReducer<TState> reducer);
	}
}
