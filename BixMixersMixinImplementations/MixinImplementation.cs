﻿using BixMixersMixinDefinitions;
using System;
using System.Collections.Generic;

namespace BixMixersMixinImplementations
{
    public class MixinImplementation : IMixinDefinition
    {
        public int Property { get { return int.MinValue; } }

        int IMixinDefinition.Property { get { return Field; } }

        public List<string> Method(int arg0, params string[] args)
        {
            var strings = new List<string>(args.Length + 1) {arg0.ToString()};
            strings.AddRange(args);
            OnAFunnyThingHappened(new UnhandledExceptionEventArgs(new InvalidOperationException("Funny"), false));
            return strings;
        }

        public event EventHandler<UnhandledExceptionEventArgs> AFunnyThingHappened;
        protected virtual void OnAFunnyThingHappened(UnhandledExceptionEventArgs e)
        {
            if (e == null) { throw new ArgumentNullException("e"); }
            var eventHandler = AFunnyThingHappened;
            if (eventHandler != null) { eventHandler(this, e); }
        }

        public int Field;

        public SomeDelegateType SomeDelegate { get { return arg0 => arg0; } }

        [Flags]
        public enum Attributes
        {
            Nothing = 0x0,
            Thing1 = 0x1,
            Thing2 = 0x2,
            Thing3 = 0x4,
            Thing4 = 0x8,
            Thing5 = 0x10
        }

        public delegate string SomeDelegateType(string arg0);
        public struct NestedStruct { public int Value; }
        public class NestedEventArgs : EventArgs { public Attributes Things; }

        public static int StaticField;
        public static int StaticProperty { get; set; }
        public static int StaticMethod(string arg0)
        {
            OnNestedThingsHappened(new NestedEventArgs());
            return (arg0 ?? string.Empty).Length;
        }
        public static event EventHandler<NestedEventArgs> NestedThingsHappened;
        private static void OnNestedThingsHappened(NestedEventArgs e)
        {
            if (e == null) { throw new ArgumentException("e"); }
            var eventHandler = NestedThingsHappened;
            if (eventHandler != null) { eventHandler(typeof(MixinImplementation), e); }
        }
    }
}
