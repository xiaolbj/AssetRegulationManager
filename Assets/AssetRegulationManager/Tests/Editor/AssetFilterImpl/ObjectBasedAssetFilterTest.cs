﻿// --------------------------------------------------------------
// Copyright 2022 CyberAgent, Inc.
// --------------------------------------------------------------

using AssetRegulationManager.Editor.Core.Model.AssetRegulations.AssetFilterImpl;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace AssetRegulationManager.Tests.Editor.AssetFilterImpl
{
    internal sealed class ObjectBasedAssetFilterTest
    {
        [Test]
        public void IsMatch_RegisterMatchedObject_ReturnTrue()
        {
            var filter = new ObjectBasedAssetFilter();
            filter.Object.Value = AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture64);
            filter.SetupForMatching();
            Assert.That(filter.IsMatch(TestAssetPaths.Texture64, null), Is.True);
        }

        [Test]
        public void IsMatch_RegisterMatchedFolder_ReturnTrue()
        {
            var filter = new ObjectBasedAssetFilter();
            filter.Object.Value = AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.BaseFolderPath);
            filter.SetupForMatching();
            Assert.That(filter.IsMatch(TestAssetPaths.Texture64, null), Is.True);
        }

        [Test]
        public void IsMatch_RegisterNotMatchedObject_ReturnFalse()
        {
            var filter = new ObjectBasedAssetFilter();
            filter.Object.Value = AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture64);
            filter.SetupForMatching();
            Assert.That(filter.IsMatch(TestAssetPaths.Texture128, null), Is.False);
        }

        [Test]
        public void IsMatch_RegisterObjectsAndContainsMatched_ReturnTrue()
        {
            var filter = new ObjectBasedAssetFilter();
            filter.Object.IsListMode = true;
            filter.Object.AddValue(AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture64));
            filter.Object.AddValue(AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture128));
            filter.SetupForMatching();
            Assert.That(filter.IsMatch(TestAssetPaths.Texture64, null), Is.True);
        }

        [Test]
        public void IsMatch_RegisterExtensionsAndNotContainsMatched_ReturnFalse()
        {
            var filter = new ObjectBasedAssetFilter();
            filter.Object.IsListMode = true;
            filter.Object.AddValue(AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture128));
            filter.Object.AddValue(AssetDatabase.LoadAssetAtPath<Object>(TestAssetPaths.Texture128MaxSize64));
            filter.SetupForMatching();
            Assert.That(filter.IsMatch(TestAssetPaths.Texture64, null), Is.False);
        }
    }
}
