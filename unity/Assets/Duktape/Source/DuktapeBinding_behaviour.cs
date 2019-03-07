using System;
using System.Collections.Generic;
using AOT;

namespace Duktape
{
    using UnityEngine;

    public partial class DuktapeBinding
    {
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _AddComponent(IntPtr ctx)
        {
            try
            {
                UnityEngine.GameObject self;
                duk_get_this(ctx, out self);
                System.Type arg0;
                duk_get_type(ctx, 0, out arg0);
                var ret = self.AddComponent(arg0);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponent(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                do
                {
                    if (argc == 1)
                    {
                        if (duk_match_types(ctx, argc, typeof(System.Type)))
                        {
                            UnityEngine.GameObject self;
                            duk_get_this(ctx, out self);
                            System.Type arg0;
                            duk_get_type(ctx, 0, out arg0);
                            var ret = self.GetComponent(arg0);
                            duk_push_any(ctx, ret);
                            return 1;
                        }
                        if (duk_match_types(ctx, argc, typeof(string)))
                        {
                            UnityEngine.GameObject self;
                            duk_get_this(ctx, out self);
                            string arg0;
                            duk_get_primitive(ctx, 0, out arg0);
                            var ret = self.GetComponent(arg0);
                            duk_push_any(ctx, ret);
                            return 1;
                        }
                        break;
                    }
                } while(false);
                return DuktapeDLL.duk_generic_error(ctx, "no matched method variant");
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponentInChildren(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                do
                {
                    if (argc == 2)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        bool arg1;
                        duk_get_primitive(ctx, 1, out arg1);
                        var ret = self.GetComponentInChildren(arg0, arg1);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                    if (argc == 1)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        var ret = self.GetComponentInChildren(arg0);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                } while(false);
                return DuktapeDLL.duk_generic_error(ctx, "no matched method variant");
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponentInParent(IntPtr ctx)
        {
            try
            {
                UnityEngine.GameObject self;
                duk_get_this(ctx, out self);
                System.Type arg0;
                duk_get_type(ctx, 0, out arg0);
                var ret = self.GetComponentInParent(arg0);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponents(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                do
                {
                    if (argc == 2)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        System.Collections.Generic.List<UnityEngine.Component> arg1;
                        duk_get_classvalue(ctx, 1, out arg1);
                        self.GetComponents(arg0, arg1);
                        return 0;
                    }
                    if (argc == 1)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        var ret = self.GetComponents(arg0);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                } while(false);
                return DuktapeDLL.duk_generic_error(ctx, "no matched method variant");
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponentsInChildren(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                do
                {
                    if (argc == 2)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        bool arg1;
                        duk_get_primitive(ctx, 1, out arg1);
                        var ret = self.GetComponentsInChildren(arg0, arg1);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                    if (argc == 1)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        var ret = self.GetComponentsInChildren(arg0);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                } while(false);
                return DuktapeDLL.duk_generic_error(ctx, "no matched method variant");
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }

        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int _GetComponentsInParent(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                do
                {
                    if (argc == 2)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        bool arg1;
                        duk_get_primitive(ctx, 1, out arg1);
                        var ret = self.GetComponentsInParent(arg0, arg1);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                    if (argc == 1)
                    {
                        UnityEngine.GameObject self;
                        duk_get_this(ctx, out self);
                        System.Type arg0;
                        duk_get_type(ctx, 0, out arg0);
                        var ret = self.GetComponentsInParent(arg0);
                        duk_push_any(ctx, ret);
                        return 1;
                    }
                } while(false);
                return DuktapeDLL.duk_generic_error(ctx, "no matched method variant");
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
    }
}