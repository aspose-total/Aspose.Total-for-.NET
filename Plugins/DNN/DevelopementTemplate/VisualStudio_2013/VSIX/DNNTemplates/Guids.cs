// Guids.cs
// MUST match guids.h
using System;

namespace DotNetNukeCorporation.DNNTemplates
{
    static class GuidList
    {
        public const string guidDNNTemplatesPkgString = "36c1422b-43ed-447c-93b6-76468752b14e";
        public const string guidDNNTemplatesCmdSetString = "722c6466-60bf-48af-98c3-c99fd81f6d5b";

        public static readonly Guid guidDNNTemplatesCmdSet = new Guid(guidDNNTemplatesCmdSetString);
    };
}