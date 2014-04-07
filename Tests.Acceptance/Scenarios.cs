using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Primitives;
using MvcIntegrationTestFramework.Hosting;
using TicTacToeConsoleApp;
using TicTacToe_Game.GameDomain;
using TicTacToe_Game.Infrastructure;
using Xunit;

namespace AcceptanceTests
{
    public class Scenarios
    {
        class ConsoleEncapsulation
        {
            public ConsoleEncapsulation()
            {
                ReadEmulator = new ConsoleReadEmulator();
                Console.SetIn(ReadEmulator);


                WriteEmulator = new ConsoleWriteEmulator();
                Console.SetOut(WriteEmulator);
            }

            public void RecordConsoleInput( params string[] inputList)
            {
                foreach (var i in inputList)
                {
                    ReadEmulator.AddInput(i);    
                }
            }

            public IEnumerable<string> ConsoleOutput { get { return WriteEmulator.ConsoleOutput; } }

            private ConsoleReadEmulator ReadEmulator { get; set; }
            private ConsoleWriteEmulator WriteEmulator { get; set; }
        
        }

        [Fact]
        public void Player_one_can_win_game()
        {
            var subject = new OurTicTacToeApp();
            var console = new ConsoleEncapsulation();

            console.RecordConsoleInput("0","4","1","5","2", "endOfInput");

            subject.Run();

            console.ConsoleOutput.Should().Contain(x => x.Contains("Player One wins"));
        }
    }

    public class ConsoleReadEmulator : TextReader
    {
        private List<string> inputBuffer;

        public ConsoleReadEmulator()
        {
            inputBuffer = new List<string>();
        }

        public void AddInput(string addToBuffer)
        {
            inputBuffer.Add(addToBuffer);
        }

        public override string ReadLine()
        {
            var first = inputBuffer[0];
            inputBuffer.RemoveAt(0);

            return first;
        }
    }

    public class ConsoleWriteEmulator : TextWriter
    {
        public List<string> buffer;

        public IEnumerable<string> ConsoleOutput { get { return buffer; } }

        public ConsoleWriteEmulator()
        {
            buffer = new List<string>();
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void WriteLine(string line)
        {
            base.WriteLine();
        }
    }

    public class TestRepositoryMock : IGameRepository
    {
        public TicTacToe_Game.GameDomain.Game GetGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public void Save(TicTacToe_Game.GameDomain.Game game)
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }
    }
}
