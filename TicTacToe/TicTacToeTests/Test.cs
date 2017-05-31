using Moq;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicTacToe.Logic;
using TicTacToe.Interfaces;
using TTTStatisticsLibrary;

namespace TicTacToeTests
{
    static class Test
    {
        public static TicTacToeFormLogic CreateLogic()
        {
            var cellButtonsSetStub = new HashSet<Button>();
            for (int i = 0; i < 9; i++)
                cellButtonsSetStub.Add(new Fixture().Build<Button>().With(b => b.TabIndex, i).OmitAutoProperties().Create());
            var labelStub = new Fixture().Build<Label>().OmitAutoProperties().Create();
            var textBoxStub = new Fixture().Build<TextBox>().OmitAutoProperties().Create();
            var imageStub = new Bitmap(1, 1);
            var statisticsWrapperMock = new Mock<IStatisticsWrapper>();
            statisticsWrapperMock.Setup(w => w.SendGameResult(It.IsAny<string>(), It.IsAny<Statistic>()));
            statisticsWrapperMock.Setup(w => w.GetStatistics(It.IsAny<string>())).Returns(new List<Statistic>());
            return new TicTacToeFormLogic(cellButtonsSetStub, labelStub, labelStub, textBoxStub,
                imageStub, imageStub, imageStub, statisticsWrapperMock.Object);
        }
    }
}
