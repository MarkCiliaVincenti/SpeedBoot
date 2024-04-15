﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace System.Reflection;

public static class MethodInfoExtensions
{
    public static bool IsAsyncMethod(this MethodInfo methodInfo)
        => typeof(Task).IsAssignableFrom(methodInfo.ReturnType) ||
            typeof(Task<>).IsAssignableFrom(methodInfo.ReturnType.GetGenericTypeDefinition());

    public static bool IsSyncMethod(this MethodInfo methodInfo)
        => !methodInfo.IsAsyncMethod();

    public static bool HasReturnValue(this MethodInfo methodInfo)
        => methodInfo.ReturnType != typeof(void) && methodInfo.ReturnType != typeof(Task);
}
