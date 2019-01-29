using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace CommandLine.Tests.Unit.Parser
{
    class FakeParserState : IParserState
    {
        public FakeParserState()
        {
            Errors = new List<ParsingError>();
        }

        public IList<ParsingError> Errors { get; private set; }
    }

    class FakeOptionsWithPreBuiltParserState
    {
        public FakeOptionsWithPreBuiltParserState()
        {
            BadParserState = new FakeParserState();
        }

        public string GetUsage()
        {
            return "FakeOptionsWithPreBuiltParserState::GetUsage()";
        }

        [Option(Required = true)]
        public string Foo { get; set; }

        [ParserState]
        public IParserState BadParserState { get; set; }
    }

    class FakeOptionsWithParserStateAttributeAppliedInWrongWay
    {
        public FakeOptionsWithParserStateAttributeAppliedInWrongWay()
        {
            EvenWorseParserState = string.Empty;
        }

        [Option(Required = true)]
        public string Bar { get; set; }

        [ParserState]
        public string EvenWorseParserState { get; set; }
    }

    class FakeOptionsWithParserStateAttributeAppliedInWrongWayAndNotInitialized
    {
        [Option(Required = true)]
        public string Bar { get; set; }

        [ParserState]
        public StringBuilder EvenWorseParserState { get; set; }
    }

   
}
