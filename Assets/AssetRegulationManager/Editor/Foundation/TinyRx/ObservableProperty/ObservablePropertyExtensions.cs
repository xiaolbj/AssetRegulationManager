﻿// --------------------------------------------------------------
// Copyright 2022 CyberAgent, Inc.
// --------------------------------------------------------------

namespace AssetRegulationManager.Editor.Foundation.TinyRx.ObservableProperty
{
    public static class ObservablePropertyExtensions
    {
        public static ReadOnlyObservableProperty<T> ToReadOnly<T>(this IObservableProperty<T> self)
        {
            return new ReadOnlyObservableProperty<T>(self);
        }
    }
}
