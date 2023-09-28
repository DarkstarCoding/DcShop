﻿using System;

namespace ZhonTai.Api.Core.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class OrderGuidAttribute : Attribute
{
    public bool Enable { get; set; } = true;
}