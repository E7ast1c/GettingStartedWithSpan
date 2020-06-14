using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStartedWithSpan
{
    public class ConcateString
    {
        private readonly string[] sampleStringArray = new string[] {
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
            "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
            "It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages," +
            " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
        };

        [Benchmark]
        public string RunCompareCommon ()=> CompareCommon(sampleStringArray);

        [Benchmark]
        public string RunCompareCommonSpan() => CompareCommonSpan(sampleStringArray);

        [Benchmark]
        public string RunCompareStringBuilder() => CompareStringBuilder(sampleStringArray);

        [Benchmark]
        public string RunCompareStringBuilderSpan() => CompareStringBuilderSpan(sampleStringArray);


        private string CompareCommon(string[] StrArr)
        {
            var result = string.Empty;
            foreach (var str in StrArr)
            {
                result += str;
            }
            return result;
        }

        private string CompareCommonSpan(ReadOnlySpan<string> span)
        {
            var result = string.Empty;
            foreach (var str in span)
            {
                result += str;
            }
            return result;
        }

        private string CompareStringBuilder(string[] StrArr)
        {
            var sb = new StringBuilder();
            foreach (var str in StrArr)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }

        private string CompareStringBuilderSpan(ReadOnlySpan<string> span)
        {
            var sb = new StringBuilder();
            foreach (var str in span)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }
    }
}
